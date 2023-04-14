using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Consoles
{
    public class ConsoleService : IConsoleService
    {
        private const string _connectionString = "Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr";
        private readonly IConsoleRepository _consolesLibrary;

        public ConsoleService(IConsoleRepository _consolesLibrary)
        {
            this._consolesLibrary = _consolesLibrary;
        }

        public List<Console> GetAll()
        {
            var consoles = _consolesLibrary.GetAll().Select(dto => dto.ToConsole()).ToList();
            return consoles;
        }

        public Console GetConsole(string name)
        {
            var consoleDTO = _consolesLibrary.GetConsole(name);
            return consoleDTO.Value.ToConsole();
        }

        public void AddConsole(string type, string model, string manufacturer, string releaseDate, string urlConsole, string controllerType, string chatPlatform)
        {
            _consolesLibrary.AddConsole(type,model, manufacturer, releaseDate, urlConsole, controllerType, chatPlatform);
        }

        public void RemoveConsole(string console)
        {
            _consolesLibrary.RemoveConsole(console);
        }

    }
}
