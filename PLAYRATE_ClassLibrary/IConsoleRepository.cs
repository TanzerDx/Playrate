using PLAYRATE_ClassLibrary.Consoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary
{
    public interface IConsoleRepository
    {
        List<ConsoleDTO> GetAll();

        List<string> GetConsoleByName();

        ConsoleDTO? GetConsole(string name);

        int? GetConsoleID(string console);

		void AddConsole(string type, string model, string manufacturer, string releaseDate, string urlConsole, string controllerType, string chatPlatform);
        void RemoveConsole(string console);
    }
}
