using ConsoleBuildTool.Models.Data;
using System.Xml.Linq;

namespace ConsoleBuildTool.Logics
{
    public class ProjectFileOperation
    {
        private readonly Appsettings _appsettings;

        public ProjectFileOperation ( Appsettings appsettings )
        {
            _appsettings = appsettings;
        }

        public Dictionary<string , bool> Execute ()
        {
            Dictionary<string , bool> appDict = new Dictionary<string , bool>();
            foreach ( string appName in _appsettings.ApplicationTitleList.Distinct () )
            {
                string projectFilePath = GetProjectFilePath ( appName );
                if ( string.IsNullOrEmpty ( projectFilePath ) )
                {
                    Console.WriteLine ( $"Project file for {appName} not found." );
                    appDict.Add ( appName , false );
                    continue;
                }

                XDocument projectFile = LoadProjectFile ( projectFilePath );
                UpdateProjectFile ( ref projectFile );

                SaveProjectFile ( projectFile , projectFilePath );
                appDict.Add ( appName , true );
            }

            return appDict;
        }

        private string GetProjectFilePath ( string appName )
        {
            string basePath = Path.Combine ( Directory.GetCurrentDirectory () , ".." , ".." , appName , appName , $"{appName}.csproj" );

#if DEBUG
            basePath = Path.Combine ( Directory.GetCurrentDirectory () , ".." , ".." , ".." , ".." , ".." , appName , appName , $"{appName}.csproj" );
#endif

            string fullPath = Path.GetFullPath ( basePath );
            if ( File.Exists ( fullPath ) )
            {
                return fullPath;
            }

            return string.Empty;
        }
        private XDocument LoadProjectFile ( string projectFilePath )
        {
            return XDocument.Load ( projectFilePath );
        }

        private void UpdateProjectFile ( ref XDocument projectFile )
        {
            XElement? project = projectFile.Root;
            if ( project is null || !project.Name.LocalName.Equals ( "Project" ) )
            {
                Console.WriteLine ( "有効なプロジェクトファイルでなかった。" );
                return;
            }

            // 最初のPropertyGroupを取得（存在しなければ作成）
            XElement? propertyGroup = project.Element( "PropertyGroup" );
            if ( propertyGroup is null )
            {
                propertyGroup = new XElement ( "PropertyGroup" );
                project.AddFirst ( propertyGroup );
            }

            UpdateFileVersion ( ref propertyGroup );
            CreateProduct ( ref propertyGroup );
            CreateCompany ( ref propertyGroup );
            CreateAuthors ( ref propertyGroup );
            CreateCopyright ( ref propertyGroup );
        }

        private void UpdateFileVersion ( ref XElement element )
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

        private void CreateProduct ( ref XElement element )
        {
            XElement? product = element.Element ( "Product" );
            if ( product is null )
            {
                XElement newProduct = new XElement ( "Product" , "TestSystems" );
                element.Add ( newProduct );
            }
        }

        private void CreateCompany ( ref XElement element )
        {
            XElement? company = element.Element ( "Company" );
            if ( company is null )
            {
                XElement newCompany = new XElement ( "Company" , "TestCompany" );
                element.Add ( newCompany );
            }
        }

        private void CreateAuthors ( ref XElement element )
        {
            XElement? authors = element.Element ( "Authors" );
            if ( authors is null )
            {
                XElement newAuthors = new XElement ( "Authors" , "TestAuthors" );
                element.Add ( newAuthors );
            }
        }

        private void CreateCopyright ( ref XElement element )
        {
            XElement? copyright = element.Element ( "Copyright" );
            if ( copyright is null )
            {
                XElement newCopyright = new XElement ( "Copyright" , "TestCompany©" );
                element.Add ( newCopyright );
            }
        }

        private void SaveProjectFile ( XDocument project , string projectFilePath )
        {
            project.Save ( projectFilePath );
        }
    }
}
