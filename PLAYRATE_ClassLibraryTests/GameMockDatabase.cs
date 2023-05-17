using PLAYRATE_ClassLibrary.Consoles;
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

        public void AddGame(int id, string name, string genre, DateTime releaseDate, string developer, double rating, string desc, string URL_Game, string URL_Page)
        {
            PLAYRATE_ClassLibrary.Games.Game game = new PLAYRATE_ClassLibrary.Games.Game(id, name, genre, releaseDate, developer, rating, desc, URL_Game, URL_Page);
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
