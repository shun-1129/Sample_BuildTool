using BuildTool.Models.Data;

namespace BuildTool.Logics
{
    public class ApplicationMoving
    {
        private readonly Appsettings _appsettings;

        public ApplicationMoving ( Appsettings appsettings )
        {
            _appsettings = appsettings;
        }

        public void Execute ()
        {
            foreach ( string appName in _appsettings.ApplicationTitleList )
            {
                string sourceAppPath = GetSourceAppPath ( appName );
                string destAppPath = GetDestAppPath ();

                CopyAppDirectory ( appName , sourceAppPath, destAppPath );
            }
        }

        private string GetSourceAppPath ( string appName )
        {
            string basePath = Path.Combine ( Directory.GetCurrentDirectory () , ".." , ".." , appName , appName , "bin" , "Release" , "net8.0" );
#if DEBUG
            basePath = Path.Combine ( Directory.GetCurrentDirectory () , ".." , ".." , ".." , ".." , ".." , appName , appName , "bin" , "Release" , "net8.0" );
#endif

            string fullPath = Path.GetFullPath ( basePath );

            if ( Directory.Exists ( fullPath ) )
            {
                return fullPath;
            }

            basePath = Path.Combine ( Directory.GetCurrentDirectory () , ".." , ".." , appName , appName , "bin" , "Release" , "net8.0-windows" );
#if DEBUG
            basePath = Path.Combine ( Directory.GetCurrentDirectory () , ".." , ".." , ".." , ".." , ".." , appName , appName , "bin" , "Release" , "net8.0-windows" );
#endif

            fullPath = Path.GetFullPath ( basePath );

            if ( Directory.Exists ( fullPath ) )
            {
                return fullPath;
            }

            return string.Empty;
        }

        private string GetDestAppPath ()
        {
            string basePath = Path.Combine ( Directory.GetCurrentDirectory () , ".." , ".." , "bin" );
#if DEBUG
            basePath = Path.Combine ( Directory.GetCurrentDirectory () , ".." , ".." , ".." , ".." , ".." , "bin" );
#endif
            string fullPath = Path.GetFullPath ( basePath );

            if ( Directory.Exists ( fullPath ) )
            {
                return fullPath;
            }

            return string.Empty;
        }

        private void CopyAppDirectory ( string appName , string sourceAppPath , string destAppPath )
        {
            if ( string.IsNullOrEmpty ( destAppPath ) )
            {
                return;
            }

            string newDestAppPath = Path.Combine ( destAppPath , appName );
            Directory.CreateDirectory ( newDestAppPath );

            if ( string.IsNullOrEmpty ( sourceAppPath ) || string.IsNullOrEmpty ( newDestAppPath ) )
            {
                Console.WriteLine ( "元のパスもしくは、送り先パスが存在しない" );
                return;
            }

            CopyDirectory ( sourceAppPath , newDestAppPath );
        }

        private static void CopyDirectory ( string sourceDir , string destDir )
        {
            Directory.CreateDirectory ( destDir );
            foreach ( string file in Directory.GetFiles ( sourceDir ) )
            {
                string destFile = Path.Combine ( destDir , Path.GetFileName ( file ) );
                File.Copy ( file , destFile , true );
            }

            foreach ( string directory in Directory.GetDirectories ( sourceDir ) )
            {
                string destSubDir = Path.Combine ( destDir , Path.GetFileName ( directory ) );
                CopyDirectory ( directory , destSubDir );
            }
        }
    }
}
