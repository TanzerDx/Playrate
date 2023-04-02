using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection.Consoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Consoles
{
    public interface IConsoleService
    {
        List<Console> GetAll();
        Console? GetConsole(string name);
        void AddConsole(string type, string model, string manufacturer, string releaseDate, string urlConsole, string controllerType, string chatPlatform);
        void RemoveConsole(string console);
    }
}
