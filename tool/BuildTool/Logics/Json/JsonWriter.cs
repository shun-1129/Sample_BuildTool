using System.Text.Json;

namespace BuildTool.Logics.Json
{
    public class JsonWriter
    {
        public static void WriteJson<T> ( T obj , string jsonFilePath , string rootKey = "" ) where T : class
        {
            string jsonString = string.Empty;
            if ( string.IsNullOrEmpty ( rootKey ) )
            {
                KeyValuePair<string , T> jsonData = new KeyValuePair<string , T> ( rootKey , obj );
                jsonString = JsonSerializer.Serialize ( jsonData );

                File.WriteAllText ( jsonString, jsonFilePath );
                return;
            }

            jsonString = JsonSerializer.Serialize ( obj );
            File.WriteAllText( jsonString, jsonFilePath );
        }

        public static async Task WriteJsonAsync<T> ( T obj , string jsonFilePath , string rootKey = "" ) where T : class
        {
            using FileStream fileStream = File.Create ( jsonFilePath );

            string jsonString = string.Empty;
            if ( !string.IsNullOrEmpty ( rootKey ) )
            {
                Dictionary<string , T> jsonData = new Dictionary<string, T> ()
                {
                    { rootKey , obj }
                };

                await JsonSerializer.SerializeAsync ( fileStream , jsonData );
                return;
            }

            await JsonSerializer.SerializeAsync ( fileStream , obj );
        }
    }
}
