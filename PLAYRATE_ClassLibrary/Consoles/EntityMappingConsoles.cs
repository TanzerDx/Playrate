using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection.Consoles;
using PLAYRATE_DatabaseConnection.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Consoles
{
    public static class EntityMappingConsoles
    {
        public static Console ToConsole(this ConsoleDTO consoleDTO)
        {
            return new Console()
            {
                ID = consoleDTO.ID,
                Model = consoleDTO.Model,
                Manufacturer = consoleDTO.Manufacturer,
                Release_Date = consoleDTO.Release_Date,
                URL_Console = consoleDTO.URL_Console,
                Controller_Type = consoleDTO.Controller_Type,
                Chat_Platform = consoleDTO.Chat_Platform
            };
        }

        public static ConsoleDTO ToConsoleDTO(this Console console)
        {
            return new ConsoleDTO()
            {
                ID = console.ID,
                Model = console.Model,
                Manufacturer = console.Manufacturer,
                Release_Date = console.Release_Date,
                URL_Console = console.URL_Console,
                Controller_Type = console.Controller_Type,
                Chat_Platform = console.Chat_Platform
            };
        }
    }
}
