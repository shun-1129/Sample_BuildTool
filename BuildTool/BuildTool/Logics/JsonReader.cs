using BuildTool.Models.Data;
using System.Text.Json;

namespace BuildTool.Logics
{
    public class JsonReader
    {
        private const string APP_SETTINGS_FILE = "appsettings.json";

        public static bool LoadAppsettings ( out Appsettings appsettings )
        {
            try
            {
                string rootPath = Directory.GetCurrentDirectory ();
                string appsettingsPath = Path.Combine ( rootPath, APP_SETTINGS_FILE );

                string jsonString = File.ReadAllText ( appsettingsPath );
                JsonElement jsonElement = JsonDocument.Parse ( jsonString ).RootElement.GetProperty ( "Appsettings" );
                appsettings = JsonSerializer.Deserialize<Appsettings> ( jsonElement.GetRawText () ) ?? new Appsettings ();

                return true;
            }
            catch ( Exception ex )
            {
                appsettings = new Appsettings ();
                return false;
            }
        }
    }
}
