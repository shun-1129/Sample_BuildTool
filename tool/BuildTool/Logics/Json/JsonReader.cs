using System.Text.Json;

namespace BuildTool.Logics.Json
{
    public class JsonReader
    {
        public static T ReadJson<T> ( string jsonFileName , string readKey = "" )
        {
            string jsonString = File.ReadAllText ( Path.Combine ( AppContext.BaseDirectory , jsonFileName ) );
            if ( string.IsNullOrEmpty ( jsonString ) )
            {
                return JsonSerializer.Deserialize<T> ( jsonString ) ?? default!;
            }

            if ( JsonDocument.Parse ( jsonString ).RootElement.TryGetProperty ( readKey , out JsonElement jsonElement ) )
            {
                return jsonElement .Deserialize<T> ( ) ?? default!;
            }

            return default!;
        }

        public static async Task<T> ReadJsonAsync<T> ( string jsonFileName , string readKey = "" )
        {
            using FileStream fileStream = File.OpenRead ( Path.Combine ( AppContext.BaseDirectory , jsonFileName ) );
            if ( string.IsNullOrEmpty ( readKey ) )
            {
                return await JsonSerializer.DeserializeAsync<T> ( fileStream ) ?? default!;
            }

            //bool hasParse = JsonDocument.TryParseValue ( ref  );
            JsonDocument jsonDocument = await JsonDocument.ParseAsync ( fileStream );
            if ( jsonDocument.RootElement.TryGetProperty ( readKey , out JsonElement jsonElement ) )
            {
                return jsonElement .Deserialize<T> ( ) ?? default!;
            }

            return default!;
        }
    }
}
