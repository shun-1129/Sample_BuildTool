using ConsoleBuildTool.Models.Data;
using System.Diagnostics;

namespace ConsoleBuildTool.Logics
{
    public class ApplicationBuild
    {
        private readonly Appsettings _appsettings;

        public ApplicationBuild ( Appsettings appsettings )
        {
            _appsettings = appsettings;
        }

        public void Execute ( Dictionary<string , bool> appDict )
        {
            string batFilePath = CreateBatFilePath ();

            foreach ( var key in appDict )
            {
                if ( !key.Value )
                {
                    continue;
                }

                string filePath = GetProjectFilePath ( key.Key );
                if ( !File.Exists ( filePath ) )
                {
                    continue;
                }

                string folderPath = Path.GetDirectoryName ( filePath ) ?? string.Empty;

                ProcessStartInfo psi = new ProcessStartInfo ()
                {
                    FileName = batFilePath ,
                    Arguments = folderPath
                };

                Process process = Process.Start ( psi )!;
                process.WaitForExit ();
            }
        }

        private string CreateBatFilePath ()
        {
            string basePath = Path.Combine ( Directory.GetCurrentDirectory () , ".." , ".." , "Script" , "build.bat" );

#if DEBUG
            basePath = Path.Combine ( Directory.GetCurrentDirectory () , ".." , ".." , ".." , ".." , ".." , "Script" , "build.bat" );
#endif

            string fullPath = Path.GetFullPath ( basePath );
            if ( File.Exists ( fullPath ) )
            {
                return fullPath;
            }

            Console.WriteLine ( "バッチファイルが見つからない" );
            return string.Empty;
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
    }
}
