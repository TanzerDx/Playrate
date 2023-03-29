using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection.Games
{
    public interface IGameRepository
    {
        List<GameDTO> GetAll(string console);
        GameDTO? GetGame(string console, string name);
    }

}
