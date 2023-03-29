using PLAYRATE_DatabaseConnection.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Games
{
    public class GameService : IGameService
    {
        private const string _connectionString = "Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial " +
            "Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False";
        private readonly IGameRepository _gamesLibrary;

        public GameService()
        {
            _gamesLibrary = new GamesLibrary(_connectionString);
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
    }
}
