using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary
{
    public interface IGameRepository
    {
        List<GameDTO> GetAll(string console);
        GameDTO? GetGame(string name, string console);
        int? GetGameID(string console, string name);
        List<GameDTO> Filter(string? keyword, string? mainFilter, string? genre, string console);
        void AddGame(string console, string name, string developer, string releaseDate, string genre, string desc, string urlGame, string urlPage, int? consoleID);
        void RemoveGame(string console, string tbID);
        void SetRating(int? consoleID, int? gameID, string console);
        void CalculateNumberOfReviews(int? consoleID, int? gameID, string console);

    }

}
