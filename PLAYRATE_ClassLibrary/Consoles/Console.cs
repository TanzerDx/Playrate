using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLAYRATE_ClassLibrary.Games;

namespace PLAYRATE_ClassLibrary.Consoles
{
    public class Console
    {
        public int ID { get; init; }

        public string Model { get; init; }

        public string Manufacturer { get; init; }

        public string Release_Date { get; init; }

        public string URL_Console { get; init; }

        public string Controller_Type { get; init; }

        public string Chat_Platform { get; init; }

        public Console()
        {

        }
        public Console(int id, string model, string manufacturer, string releaseDate, string urlConsole, string controllerType, string chatPlatform)
        {
            this.ID = id;
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Release_Date = releaseDate;
            this.URL_Console = urlConsole;
            this.Controller_Type = controllerType;
            this.Chat_Platform = chatPlatform;
        }
    }
}
