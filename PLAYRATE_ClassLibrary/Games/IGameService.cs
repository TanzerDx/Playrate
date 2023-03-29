using PLAYRATE_DatabaseConnection.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Games
{
    public interface IGameService
    {
        List<Game> GetAll(string console);
        Game GetGame(string console, string name);
    }
}
