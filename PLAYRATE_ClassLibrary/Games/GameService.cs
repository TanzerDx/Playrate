﻿using BusinessLogic;
using FluentResults;
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

        public Result<List<Game>> Filter(string? keyword, string? mainFilter, string? genre, string console)
        {
            try
            {
                var games = _gamesLibrary.Filter(keyword, mainFilter, genre, console).Select(dto => dto.ToGame()).ToList();
                return games;
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to filter the games!").CausedBy(exception));
            }
        }

        public Result<List<Game>> GetRecommendations(string username)
        {
            try
            {
                var games = _gamesLibrary.GetRecommendations(username).Select(dto => dto.ToGame()).ToList();
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

        public void SetRating(Result<int?> consoleID, Result<int?> gameID, string console)
        {
            try
            { 
                _gamesLibrary.SetRating(consoleID.Value, gameID.Value, console);
		    }
            catch (Exception exception)
            {
                Result.Fail(new Error("Unable set the rating!").CausedBy(exception));
            }
        }

        public void CalculateNumberOfReviews(Result<int?> consoleID, Result<int?> gameID, string console)
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
    }
}
