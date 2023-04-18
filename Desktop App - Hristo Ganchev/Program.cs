using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection;

namespace Desktop_App___Hristo_Ganchev
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            IConsoleRepository consoleRepository = new ConsoleLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");
            IGameRepository gamesRepository = new GamesLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");

            Application.Run(new HomePage(consoleRepository, gamesRepository));
        }
    }
}