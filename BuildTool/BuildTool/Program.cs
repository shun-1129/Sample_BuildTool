using BuildTool.Logics;
using BuildTool.Models.Data;

namespace BuildTool
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

            ProjectFileOperation projectFileOperation = new ( appsettings );
            var data = projectFileOperation.Execute ();

            ApplicationBuild applicationBuild = new ApplicationBuild ( appsettings );
            applicationBuild.Execute ( data );

            ApplicationMoving applicationMoving = new ApplicationMoving ( appsettings );
            applicationMoving.Execute ();
        }
    }
}
