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

        public void ChangeCoontrollerType(string controllerType)
        { 
            
        }

    }
}
