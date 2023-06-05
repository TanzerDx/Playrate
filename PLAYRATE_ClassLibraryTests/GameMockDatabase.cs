using BusinessLogic;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.FilterStrategy;
using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibraryTests
{
    public class GameMockDatabase
    {
        List<PLAYRATE_ClassLibrary.Games.Game> games = new List<PLAYRATE_ClassLibrary.Games.Game>();

        public List<PLAYRATE_ClassLibrary.Games.Game> GetAll()
        {
            return games;
        }

		public List<Game> Filter(string? keyword, string? mainFilter, string? genre, List<Game> gameTest)
		{
			List<Game> games = new List<Game>(gameTest);

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


		public PLAYRATE_ClassLibrary.Games.Game GetGame(string name)
        {
            PLAYRATE_ClassLibrary.Games.Game game = null;

            foreach (PLAYRATE_ClassLibrary.Games.Game g in games)
            {
                if (g.Name == name)
                {
                    game = g;
                }

                return game;
            }

            return game;
        }

        public PLAYRATE_ClassLibrary.Games.Game GetGameByKeyword(string keyword)
        {
            PLAYRATE_ClassLibrary.Games.Game game = null;

            foreach (PLAYRATE_ClassLibrary.Games.Game g in games)
            {
                if (g.Name.Contains(keyword))
                {
                    game = g;
                }

                return game;
            }

            return game;
        }

        public PLAYRATE_ClassLibrary.Games.Game GetByGenre(string genre)
        {
            PLAYRATE_ClassLibrary.Games.Game game = null;

            foreach (PLAYRATE_ClassLibrary.Games.Game g in games)
            {
                if (g.Genre == genre)
                {
                    game = g;
                }

                return game;
            }

            return game;
        }

        public int CountGamesWithThisGenre(string genre)
        {
            PLAYRATE_ClassLibrary.Games.Game game = null;
            int count = 0;

            foreach (PLAYRATE_ClassLibrary.Games.Game g in games)
            {
                if (g.Genre == genre)
                {
                    count++;
                }

                return count;
            }

            return count;
        }

        public void AddGame(int id, string name, string genre, DateTime releaseDate, string developer, double rating, string desc, string URL_Game, string URL_Page, int consoleID, int reviews)
        {
            PLAYRATE_ClassLibrary.Games.Game game = new Game(id, name, genre, Convert.ToDateTime(releaseDate), developer, rating, desc, URL_Game, URL_Page, 1, 1);
            games.Add(game);
        }

        public void RemoveGame(string name)
        {
            foreach (PLAYRATE_ClassLibrary.Games.Game g in games)
            {
                if (g.Name == name)
                {
                    games.Remove(g);
                }
            }
        }
    }
}
