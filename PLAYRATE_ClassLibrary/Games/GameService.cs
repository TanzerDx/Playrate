﻿using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Games
{
    public class GameService : IGameService
    {
        private const string _connectionString = "Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr";
        private readonly IGameRepository _gamesLibrary;

        public GameService(IGameRepository _gamesLibrary)
        {
            this._gamesLibrary = _gamesLibrary;
        }

        public List<Game> GetAll(string console)
        {
            var games = _gamesLibrary.GetAll(console).Select(dto => dto.ToGame()).ToList();
            return games;
        }

        public Game GetGame(string name, string console)
        {
            var gameDTO = _gamesLibrary.GetGame(name, console);
            return gameDTO.Value.ToGame();
        }

        public int? GetGameID(string console, string name)
        {
            int? gameID = _gamesLibrary.GetGameID(console, name);
            return gameID;
        }

        public List<Game> Filter(string? keyword, string? mainFilter, string? genre, string console)
        {
            var games = _gamesLibrary.Filter(keyword, mainFilter, genre, console).Select(dto => dto.ToGame()).ToList();
            return games;
        }

        public List<Game> GetRecommendations(string console)
        {
            var games = _gamesLibrary.GetRecommendations(console).Select(dto => dto.ToGame()).ToList();
            return games;
        }

        public void AddGame(string console, string name, string developer, DateTime releaseDate, string genre, string desc, string urlGame, string urlPage, int? consoleID)
        {
            _gamesLibrary.AddGame(console, name, developer, releaseDate, genre, desc, urlGame, urlPage, consoleID);
        }

        public void RemoveGame(string console, string tbID)
        {
            _gamesLibrary.RemoveGame(console, tbID);
        }

        public void SetRating(int? consoleID, int? gameID, string console)
        {
            _gamesLibrary.SetRating(consoleID, gameID, console);
        }

        public void CalculateNumberOfReviews(int? consoleID, int? gameID, string console)
        {
            _gamesLibrary.CalculateNumberOfReviews(consoleID, gameID, console);
        }
    }
}
