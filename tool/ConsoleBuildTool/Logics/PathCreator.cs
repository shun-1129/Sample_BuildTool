namespace ConsoleBuildTool.Logics
{
    public class PathCreator
    {
        private const string PARENT_FOLDER_NAME = "Sample_BuildTool";
        private const string RETURN_PATH = "..";
        private const string PROJECT_FILE_EXTENTION = ".csproj";
        private const string BIN_DIRECTORY_NAME = "bin";
        private const string FREAMWORK_DEFAULT = "net8.0";
        private const string FREAMWORK_WINDOWS = "net8.0-windows";
        private const string SCRIPT_DIRECTORY_NAME = "script";

        /// <summary>
        /// プロジェクトファイルの絶対パスを取得する
        /// </summary>
        /// <param name="applicationName">アプリケーション名称</param>
        /// <returns>プロジェクトファイルの絶対パス</returns>
        public static string GetProjectFilePath ( string applicationName )
        {
            string path = GetBasePath ();

            string[] filePathArray = Directory.GetFiles ( path , $"{applicationName}{PROJECT_FILE_EXTENTION}" , SearchOption.AllDirectories );
            if ( filePathArray is null || 0 == filePathArray.Length || 2 <= filePathArray.Length )
            {
                return string.Empty;
            }

            return filePathArray.First ();
        }

        /// <summary>
        /// アプリケーションbinフォルダの絶対パスを取得する
        /// </summary>
        /// <param name="applicationName">アプリケーション名称</param>
        /// <param name="configuration">
        /// ビルド設定<br/>
        /// Debug or Release
        /// </param>
        /// <returns>アプリケーションbinフォルダの絶対パス</returns>
        public static string GetApplicationBinPath ( string applicationName , string configuration )
        {
            string path = GetProjectFilePath ( applicationName );
            if ( string.IsNullOrEmpty ( path ) )
            {
                return string.Empty;
            }

            string rootParh = Path.GetDirectoryName ( path ) ?? string.Empty;
            if ( string.IsNullOrEmpty ( path ) )
            {
                return string.Empty;
            }

            path = Path.Combine ( rootParh , BIN_DIRECTORY_NAME , configuration , FREAMWORK_DEFAULT );
            if ( Directory.Exists ( path ) )
            {
                return Path.GetFullPath ( path );
            }

            path = Path.Combine ( rootParh , BIN_DIRECTORY_NAME , configuration , FREAMWORK_WINDOWS );
            if ( Directory.Exists ( path ) )
            {
                return Path.GetFullPath ( path );
            }

            return string.Empty;
        }

        /// <summary>
        /// バッチファイルの絶対パスを取得する
        /// </summary>
        /// <param name="batchFileName">バッチファイル名称</param>
        /// <returns>バッチファイルの絶対パス</returns>
        public static string GetBatchFilePath ( string batchFileName )
        {
            string path = GetBasePath ();
            string[] filePathArray = Directory.GetDirectories ( Path.Combine ( path , SCRIPT_DIRECTORY_NAME ) , batchFileName , SearchOption.AllDirectories );
            if ( filePathArray is null || 0 == filePathArray.Length || 2 <= filePathArray.Length )
            {
                return string.Empty;
            }

            return filePathArray.First ();
        }

        /// <summary>
        /// ベースの絶対パスを取得する
        /// </summary>
        /// <returns>ベースの絶対パス</returns>
        private static string GetBasePath ()
        {
            string path = AppContext.BaseDirectory;
            bool isCallback = false;
            while ( !CheckDirectoryPath ( ref path , isCallback ) )
            {
                isCallback = true;
            }

            return path;
        }

        /// <summary>
        /// ベースとなるフォルダパスかを確認する
        /// </summary>
        /// <param name="path">確認対象のパス</param>
        /// <param name="isCallback">再起で呼び出したか</param>
        /// <returns>
        /// ベースだった：<see langword="true"/><br/>
        /// ベースでない：<see langword="false"/>
        /// </returns>
        private static bool CheckDirectoryPath ( ref string path , bool isCallback = false )
        {
            if ( isCallback )
            {
                path = Path.GetFullPath ( Path.Combine ( path , RETURN_PATH ) );
            }

            string[] directoryNames = path.Split ( '\\' );

            if ( PARENT_FOLDER_NAME.Equals ( directoryNames[^1] ) )
            {
                return true;
            }

            return false;
        }
    }
}
