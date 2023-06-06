using BusinessLogic;
using FluentResults;
using PLAYRATE_ClassLibrary.FilterStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Games
{
    public class GameService : IGameService
    {   
        private readonly IGameRepository _gamesLibrary;

        public GameService(IGameRepository _gamesLibrary)
        {
            this._gamesLibrary = _gamesLibrary;
        }

		public Result<List<Game>> GetAll(string console)
		{
            try
            {
                var games = _gamesLibrary.GetAll(console).Select(dto => dto.ToGame()).ToList();
                return games;
            }
			catch (Exception exception)
			{
				return Result.Fail(new Error("Unable to retrieve all games!").CausedBy(exception));
			}
}

		public Result<Game> GetGame(string name, string console)
        {
            try
            {
                var gameDTO = _gamesLibrary.GetGame(name, console);
                return gameDTO.Value.ToGame();
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to get the game!").CausedBy(exception));
            }
        }

        public Result<int?> GetGameID(string console, string name)
        {
            try
            {
                int? gameID = _gamesLibrary.GetGameID(name, console);
                return gameID;
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to get the game ID!").CausedBy(exception));
            }
        }

        public Result<List<Game>> Filter(string? keyword, string? mainFilter, string? genre, List<Game> toFilter)
        {
            try
            {
				List<Game> games = new List<Game>();

                games = toFilter;

				IFilterStrategy filterStrategy = null;

				List<IFilterStrategy> strategies = new List<IFilterStrategy>()
			    {
				    new FilterBy_Keyword_Strategy(),
				    new FilterBy_MainFilter_Strategy(),
				    new FilterBy_Genre_Strategy(),
				    new FilterBy_KeywordAndMainFilter_Strategy(),
				    new FilterBy_KeywordAndGenre_Strategy(),
				    new FilterBy_MainFilterAndGenre_Strategy(),
				    new FilterBy_All_Strategy()
			    };

				foreach (IFilterStrategy filter in strategies)
				{
					if (filter.ShouldApply(keyword, mainFilter, genre))
					{
						filterStrategy = filter;
						break;
					}
				}

				if (filterStrategy != null)
				{
					games = filterStrategy.ApplyFilter(keyword, mainFilter, genre, games);
				}

				return games;
			}
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to filter the games!").CausedBy(exception));
            }
        }

        public Result<List<Game>> GetRecommendations(string username, double minimum, double maximum)
		{
            try
            {
                var games = _gamesLibrary.GetRecommendations(username, minimum, maximum).Select(dto => dto.ToGame()).ToList();
                return games;
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to retrieve recommendations!").CausedBy(exception));
            }
        }

        public void AddGame(string console, string name, string developer, DateTime releaseDate, string genre, string desc, string urlGame, string urlPage, int? consoleID)
        {
            try
            {
                _gamesLibrary.AddGame(console, name, developer, releaseDate, genre, desc, urlGame, urlPage, consoleID);
		    }
            catch (Exception exception)
            {
                Result.Fail(new Error("Unable to add the game!").CausedBy(exception));
            }
        }

        public void RemoveGame(string console, string tbID)
        {
            try 
            {
                _gamesLibrary.RemoveGame(console, tbID);
		    }
            catch (Exception exception)
            {
                Result.Fail(new Error("Unable to remove the game!").CausedBy(exception));
            }
        }

        public void SetRating(int? consoleID, int? gameID, string console)
        {
            try
            { 
                _gamesLibrary.SetRating(consoleID, gameID, console);
		    }
            catch (Exception exception)
            {
                Result.Fail(new Error("Unable set the rating!").CausedBy(exception));
            }
        }

        public void CalculateNumberOfReviews(int? consoleID, int? gameID, string console)
        {
            try
            {
                _gamesLibrary.CalculateNumberOfReviews(consoleID, gameID, console);
		    }
            catch (Exception exception)
            {
                Result.Fail(new Error("Unable to calculate number of reviews!").CausedBy(exception));
            }
        }

        public Result<List<Game>> StatisticsHighestRating()
        {
            try
            {
                var games = _gamesLibrary.GetAllGames().OrderByDescending(game => game.Rating).Take(5).Select(dto => dto.ToGame()).ToList();
                return games;
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to retrieve recommendations!").CausedBy(exception));
            }
        }

        public Result<List<Game>> StatisticsMostReviews()
        {
            try
            {
                var games = _gamesLibrary.GetAllGames().OrderByDescending(game => game.Reviews).Take(5).Select(dto => dto.ToGame()).ToList();
                return games;
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to retrieve recommendations!").CausedBy(exception));
            }
        }
    }
}
