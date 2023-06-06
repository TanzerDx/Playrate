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
        Result<List<Game>> Filter(string? keyword, string? mainFilter, string? genre, List<Game> toFilter);
        Result<List<Game>> GetRecommendations(string username, double minimum, double maximum);
        void AddGame(string console, string name, string developer, DateTime releaseDate, string genre, string desc, string urlGame, string urlPage, int? consoleID);
        void RemoveGame(string console, string tbID);
        void SetRating(int? consoleID, int? gameID, string console);
        void CalculateNumberOfReviews(int? consoleID, int? gameID, string console);
        Result<List<Game>> StatisticsHighestRating();
        Result<List<Game>> StatisticsMostReviews();
    }
}
