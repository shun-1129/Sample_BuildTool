using ConsoleBuildTool.Logics;
using ConsoleBuildTool.Models.Data;

namespace ConsoleBuildTool
{
    public class Program
    {
        public static void Main ( string[] args )
        {
            if ( !JsonReader.LoadAppsettings ( out Appsettings appsettings ) )
            {
                Console.WriteLine ( "Failed to load appsettings.json" );
                return;
            }

            string configuration = string.Empty;
            if ( args.Length == 0 )
            {
                configuration = "Debug";
            }
            else if ( args[0].Equals ( "Debug" ) || args[0].Equals ( "Release" ) )
            {
                configuration = args[0];
            }
            else
            {
                configuration = "Debug";
            }

            ProjectFileOperation projectFileOperation = new ( appsettings );
            var data = projectFileOperation.Execute ();

            ApplicationBuild applicationBuild = new ( appsettings );
            applicationBuild.Execute ( data );

            ApplicationMoving applicationMoving = new ( appsettings );
            applicationMoving.Execute ();
        }
    }
}
