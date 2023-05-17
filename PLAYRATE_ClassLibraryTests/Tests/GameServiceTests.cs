using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibraryTests;
using PLAYRATE_DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Games.Tests
{
    [TestClass()]
    public class GameServiceTests
    {

        GameMockDatabase gamesService;

        public GameServiceTests()
        {
            gamesService = new GameMockDatabase();
        }

        [TestMethod()]
        public void AddGameTest()
        {
            int id = 1;
            string name = "Something";
            string developer = "Developer";
            DateTime releaseDate = Convert.ToDateTime("14/05/2020");
            string genre = "Fantasy";
            double rating = 4;
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";

            gamesService.AddGame(id, name, genre, releaseDate, developer, rating, desc, urlGame, urlPage);

            Assert.IsNotNull(gamesService.GetAll());

        }

        [TestMethod()]
        public void RemoveGameTest()
        {
            string name = "Something";

            gamesService.RemoveGame(name);

            Assert.AreEqual(null , gamesService.GetGame(name));

        }

        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            int id = 1;
            string name = "Something";
            string developer = "Developer";
            DateTime releaseDate = Convert.ToDateTime("14/05/2020");
            string genre = "Fantasy";
            double rating = 4;
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";

            //Act
            gamesService.AddGame(id, name, genre, releaseDate, developer, rating, desc, urlGame, urlPage);

            //Assert
            Assert.IsNotNull(gamesService.GetAll());

        }

        [TestMethod()]
        public void GetGameTest()
        {
            int id = 1;
            string name = "Something";
            string developer = "Developer";
            DateTime releaseDate = Convert.ToDateTime("14/05/2020");
            string genre = "Fantasy";
            double rating = 4;
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";

            gamesService.AddGame(id, name, genre, releaseDate, developer, rating, desc, urlGame, urlPage);

            Assert.AreEqual("PLAYRATE_ClassLibrary.Games.Game", gamesService.GetGame(name).ToString());


        }

        [TestMethod()]
        public void At_Least_One_Game_With_This_Genre()
        {
            int id = 1;
            string name = "Something";
            string developer = "Developer";
			DateTime releaseDate = Convert.ToDateTime("14/05/2020");
			string genre = "Fantasy";
            double rating = 4;
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";

            gamesService.AddGame(id, name, genre, releaseDate, developer, rating, desc, urlGame, urlPage);

            Assert.AreEqual(1, gamesService.CountGamesWithThisGenre(genre));
        }

        [TestMethod()]
        public void GetByKeywordTest()
        {
            int id = 1;
            string name = "Something";
            string developer = "Developer";
			DateTime releaseDate = Convert.ToDateTime("14/05/2020");
			string genre = "Fantasy";
            double rating = 4;
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";
            string keyword = "Som";

            gamesService.AddGame(id, name, genre, releaseDate, developer, rating, desc, urlGame, urlPage);

            Assert.IsNotNull(gamesService.GetGameByKeyword(keyword));
        }
    }
}