using PLAYRATE_DatabaseConnection.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection.Consoles
{
    public interface IConsoleRepository
    {
        List<ConsoleDTO> GetAll();
        ConsoleDTO? GetConsole(string name);
    }
}
