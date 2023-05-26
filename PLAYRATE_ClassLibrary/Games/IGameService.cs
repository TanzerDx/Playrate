using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Games
{
    public interface IGameService
    {
        Result <List<Game>> GetAll(string console);
        Result<Game> GetGame(string name, string console);
        Result<int?> GetGameID(string name, string console);
        Result<List<Game>> Filter(string? keyword, string? mainFilter, string? genre, string console);
        Result<List<Game>> GetRecommendations(string username);
        void AddGame(string console, string name, string developer, DateTime releaseDate, string genre, string desc, string urlGame, string urlPage, int? consoleID);
        void RemoveGame(string console, string tbID);
        void SetRating(Result<int?> consoleID, Result<int?> gameID, string console);
        void CalculateNumberOfReviews(Result<int?> consoleID, Result<int?> gameID, string console);
    }
}
