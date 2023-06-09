using BusinessLogic;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.FilterStrategy;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibrary.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibraryTests
{
    public class GameMockDatabase
    {
		public List<Game> GetMockDatabase()
		{
			Game game1 = new Game(1, "Something", "Fantasy", Convert.ToDateTime("2005/05/14"), "Someone", 4, "A nice game", "url", "url", 1, 5);
			Game game2 = new Game(2, "Another", "Fantasy", Convert.ToDateTime("2005/05/14"), "Someone", 4.5, "A nice game", "url", "url", 1, 7);
			Game game3 = new Game(3, "Hello", "Sci-Fi", Convert.ToDateTime("2005/05/14"), "Someone", 3, "A nice game", "url", "url", 1, 3);
			Game game4 = new Game(4, "Fontys", "Action", Convert.ToDateTime("2005/05/14"), "Someone", 5, "A nice game", "url", "url", 1, 2);
			Game game5 = new Game(5, "Amsterdam", "Sci-Fi", Convert.ToDateTime("2005/05/14"), "Someone", 2, "A nice game", "url", "url", 1, 1);

			List<Game> games = new List<Game> { game1, game2, game3, game4, game5 };

			return games;
		}

	}
}
