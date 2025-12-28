using System.Xml.Linq;

namespace BuildTool.Logics
{
    public class ProjectFileUpdaater
    {
        public static bool UpdateProjectFile ( string projectName )
        {
            string projectFilePath = PathCreator.GetProjectFilePath ( projectName );
            XDocument doc = GetProjectFileContent ( projectFilePath );
            UpdatePropertyGroup ( ref doc );
            UpdateBuildInfoPropertyGroup ( ref doc );

            SaveProjectFile ( doc , projectFilePath );

            return true;
        }

        private static XDocument GetProjectFileContent ( string projectFilePath )
        {
            return XDocument.Load ( projectFilePath );
        }

        private static void UpdatePropertyGroup ( ref XDocument document )
        {
            XElement? root = document.Root;
            if ( root is null || !root.Name.LocalName.Equals ( "Project" ) )
            {
                MessageBox.Show ( "有効なプロジェクトファイルでない" , "エラー" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            // 最初のPropertyGroupを取得（存在しなければ作成）
            XElement? propertyGroup = root.Element( "PropertyGroup" );
            if ( propertyGroup is null )
            {
                propertyGroup = new XElement ( "PropertyGroup" );
                root.AddFirst ( propertyGroup );
            }

            UpdateFileVersion ( ref propertyGroup );
            CreateProduct ( ref propertyGroup );
            CreateCompany ( ref propertyGroup );
            CreateAuthors ( ref propertyGroup );
            CreateCopyright ( ref propertyGroup );
            CreateBaseOutputPath ( ref propertyGroup );
            CreateAppendRuntimeIdentifierToOutputPath ( ref propertyGroup );
            CreateAppendTargetFrameworkToOutputPath ( ref propertyGroup );
        }

        private static void UpdateBuildInfoPropertyGroup ( ref XDocument document )
        {
            XElement? root = document.Root;
            if ( root is null || !root.Name.LocalName.Equals ( "Project" ) )
            {
                MessageBox.Show ( "有効なプロジェクトファイルでない" , "エラー" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            XNamespace xNamespace = root.Name.Namespace;

            var temp = root.Elements ( "PropertyGroup" ).ToList ();

            const string CONDITION_DEBUG = "'$(Configuration)'=='Debug'";
            const string CONDITION_RELEASE = "'$(Configuration)'=='Release'";

            if ( !HasCondition ( root , xNamespace , CONDITION_DEBUG ) )
            {
                root.Add ( CreateConditionPropertyGroup ( CONDITION_DEBUG ) );
            }

            if ( !HasCondition ( root , xNamespace , CONDITION_RELEASE ) )
            {
                root.Add ( CreateConditionPropertyGroup ( CONDITION_RELEASE ) );
            }
        }

        private static void UpdateFileVersion ( ref XElement element )
        {
            XElement? fileVersion = element.Element ( "FileVersion" );

            if ( fileVersion is null )
            {
                XElement newFileVersion = new XElement ( "FileVersion" , "1.0.0.1" );
                element.Add ( newFileVersion );
            }
            else
            {
                fileVersion.Value = "1.0.0.1";
            }
        }

        private static void CreateProduct ( ref XElement element )
        {
            XElement? product = element.Element ( "Product" );
            if ( product is null )
            {
                XElement newProduct = new XElement ( "Product" , "TestSystems" );
                element.Add ( newProduct );
            }
        }

        private static void CreateCompany ( ref XElement element )
        {
            XElement? company = element.Element ( "Company" );
            if ( company is null )
            {
                XElement newCompany = new XElement ( "Company" , "TestCompany" );
                element.Add ( newCompany );
            }
        }

        private static void CreateAuthors ( ref XElement element )
        {
            XElement? authors = element.Element ( "Authors" );
            if ( authors is null )
            {
                XElement newAuthors = new XElement ( "Authors" , "TestAuthors" );
                element.Add ( newAuthors );
            }
        }

        private static void CreateCopyright ( ref XElement element )
        {
            XElement? copyright = element.Element ( "Copyright" );
            if ( copyright is null )
            {
                XElement newCopyright = new XElement ( "Copyright" , "TestCompany©" );
                element.Add ( newCopyright );
            }
        }

        private static void CreateBaseOutputPath ( ref XElement element )
        {
            XElement? baseOutputPath = element.Element ( "BaseOutputPath" );
            if ( baseOutputPath is null )
            {
                XElement newBaseOutputPath = new XElement ( "BaseOutputPath" , @"$(SolutionDir)bin\" );
                element.Add ( newBaseOutputPath );
            }
        }

        private static void CreateAppendTargetFrameworkToOutputPath ( ref XElement element )
        {
            XElement? appendTargetFrameworkToOutputPath = element.Element ( "AppendTargetFrameworkToOutputPath" );
            if ( appendTargetFrameworkToOutputPath is null )
            {
                XElement newAppendTargetFrameworkToOutputPath = new XElement ( "AppendTargetFrameworkToOutputPath" , false );
                element.Add ( newAppendTargetFrameworkToOutputPath );
            }
        }

        private static void CreateAppendRuntimeIdentifierToOutputPath ( ref XElement element )
        {
            XElement? appendRuntimeIdentifierToOutputPath = element.Element ( "AppendRuntimeIdentifierToOutputPath" );
            if ( appendRuntimeIdentifierToOutputPath is null )
            {
                XElement newAppendRuntimeIdentifierToOutputPath = new XElement ( "AppendRuntimeIdentifierToOutputPath" , false );
                element.Add ( newAppendRuntimeIdentifierToOutputPath );
            }
        }

        private static bool HasCondition ( XElement root , XNamespace xNamespace , string condition ) => 
            root.Elements ( xNamespace + "PropertyGroup" )
                .Any ( x => x.Attribute ( "Condition" )?.Value == condition );

        private static XElement CreateConditionPropertyGroup ( string condition )
        {
            return new XElement ( "PropertyGroup" , new XAttribute ( "Condition" , condition ) , CreateOutputPathElement () );
        }

        private static XElement CreateOutputPathElement ()
        {
            return new XElement ( "OutputPath" , @"$(SolutionDir)bin\Debug\$(AssemblyName)\" );
        }

        private static void SaveProjectFile ( XDocument project , string projectFilePath )
        {
            project.Save ( projectFilePath );
        }
    }
}
