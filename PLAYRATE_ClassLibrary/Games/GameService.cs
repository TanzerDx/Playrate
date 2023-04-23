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

        public List<Game> GetByGenre(string genre, string console)
        {
            var games = _gamesLibrary.GetByGenre(genre, console).Select(dto => dto.ToGame()).ToList();
            return games;
        }

        public List<Game> GetByMainFilter(string filter, string console)
        {
            var games = _gamesLibrary.GetByMainFilter(filter, console).Select(dto => dto.ToGame()).ToList();
            return games;
        }

        public List<Game> GetByKeyword(string keyword,string console)
        {
            var games = _gamesLibrary.GetByKeyword(keyword, console).Select(dto => dto.ToGame()).ToList();
            return games;
        }

        public void AddGame(string console, string name, string developer, string releaseDate, string genre, string rating, string desc, string urlGame, string urlPage)
        {
            _gamesLibrary.AddGame(console, name, developer, releaseDate, genre, rating, desc, urlGame, urlPage);
        }

        public void RemoveGame(string console, string tbID)
        {
            _gamesLibrary.RemoveGame(console, tbID);
        }
    }
}
