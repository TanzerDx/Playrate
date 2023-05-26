using FluentResults;
using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Consoles
{
    public interface IConsoleService
    {
        Result<List<Console>> GetAll();
        Result<List<string>> GetConsoleByName();
        Result<Console?> GetConsole(string name);
		Result<int?> GetConsoleID(string console);
		void AddConsole(string type, string model, string manufacturer, DateTime releaseDate, string urlConsole, string controllerType, string chatPlatform);  
        void RemoveConsole(string console);

    }
}
