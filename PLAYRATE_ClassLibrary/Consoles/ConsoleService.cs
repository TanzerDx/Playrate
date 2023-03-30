using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection.Consoles;
using PLAYRATE_DatabaseConnection.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Consoles
{
    public class ConsoleService : IConsoleService
    {
        private const string _connectionString = "Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial " +
            "Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False";
        private readonly IConsoleRepository _consolesLibrary;

        public ConsoleService()
        {
            _consolesLibrary = new ConsoleLibrary(_connectionString);
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
    }
}
