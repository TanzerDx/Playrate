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
        Game GetGame(string name, string console);
        List<Game> GetByGenre(string genre, string console);
        List<Game> GetByMainFilter(string filter, string console);
        List<Game> GetByKeyword(string keyword, string console);
        void AddGame(string console, string name, string developer, string releaseDate, string genre, string rating, string desc, string urlGame, string urlPage);
        void RemoveGame(string console, string tbID);
    }
}
