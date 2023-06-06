using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibrary.Reviews;
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
            DateTime releaseDate = Convert.ToDateTime("2020/05/14");
            string genre = "Fantasy";
            double rating = 4;
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";

            gamesService.AddGame(id, name, genre, releaseDate, developer, rating, desc, urlGame, urlPage, 1, 1);

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
            DateTime releaseDate = Convert.ToDateTime("2020/05/14");
            string genre = "Fantasy";
            double rating = 4;
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";

            //Act
            gamesService.AddGame(id, name, genre, releaseDate, developer, rating, desc, urlGame, urlPage, 1, 1);

            //Assert
            Assert.IsNotNull(gamesService.GetAll());

        }

        [TestMethod()]
        public void GetGameTest()
        {
            int id = 1;
            string name = "Something";
            string developer = "Developer";
            DateTime releaseDate = Convert.ToDateTime("2020/05/14");
            string genre = "Fantasy";
            double rating = 4;
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";

            gamesService.AddGame(id, name, genre, releaseDate, developer, rating, desc, urlGame, urlPage, 1, 1);

            Assert.AreEqual("PLAYRATE_ClassLibrary.Games.Game", gamesService.GetGame(name).ToString());


        }

        [TestMethod()]
        public void At_Least_One_Game_With_This_Genre()
        {
            int id = 1;
            string name = "Something";
            string developer = "Developer";
			DateTime releaseDate = Convert.ToDateTime("2020/05/14");
			string genre = "Fantasy";
            double rating = 4;
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";

            gamesService.AddGame(id, name, genre, releaseDate, developer, rating, desc, urlGame, urlPage, 1, 1);

            Assert.AreEqual(1, gamesService.CountGamesWithThisGenre(genre));
        }

        [TestMethod()]
        public void GetByKeywordTest()
        {
            int id = 1;
            string name = "Something";
            string developer = "Developer";
			DateTime releaseDate = Convert.ToDateTime("2020/05/14");
			string genre = "Fantasy";
            double rating = 4;
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";
            string keyword = "Som";

            gamesService.AddGame(id, name, genre, releaseDate, developer, rating, desc, urlGame, urlPage, 1, 1);

            Assert.IsNotNull(gamesService.GetGameByKeyword(keyword));
        }

		[TestMethod()]
		public void Filter()
		{
            Game game1 = new Game(1, "Something", "Fantasy", Convert.ToDateTime("2005/05/14"), "Someone", 4, "A nice game", "url", "url", 1, 5);
			Game game2 = new Game(2, "Another", "Fantasy", Convert.ToDateTime("2005/05/14"), "Someone", 5, "A nice game", "url", "url", 1, 7);
			Game game3 = new Game(3, "Hello", "Horror", Convert.ToDateTime("2005/05/14"), "Someone", 3, "A nice game", "url", "url", 1, 3);
			Game game4 = new Game(4, "Fontys", "Action", Convert.ToDateTime("2005/05/14"), "Someone", 5, "A nice game", "url", "url", 1, 2);
			Game game5 = new Game(5, "Amsterdam", "Sci-Fi", Convert.ToDateTime("2005/05/14"), "Someone", 2, "A nice game", "url", "url", 1, 1);

			List<Game> testData = new List<Game> { game1, game2, game3, game4, game5 };

            testData = gamesService.Filter("Ano", "Rating", "Fantasy", testData);

            Assert.AreEqual(testData[0].Name, "Another");

		}

        [TestMethod]
        public void GetRecommendations()
        {
			Game game1 = new Game(1, "Something", "Fantasy", Convert.ToDateTime("2005/05/14"), "Someone", 4, "A nice game", "url", "url", 1, 5);
			Game game2 = new Game(2, "Another", "Fantasy", Convert.ToDateTime("2005/05/14"), "Someone", 5, "A nice game", "url", "url", 1, 7);
			Game game3 = new Game(3, "Hello", "Horror", Convert.ToDateTime("2005/05/14"), "Someone", 4, "A nice game", "url", "url", 1, 3);
			Game game4 = new Game(4, "Fontys", "Action", Convert.ToDateTime("2005/05/14"), "Someone", 5, "A nice game", "url", "url", 1, 2);
			Game game5 = new Game(5, "Amsterdam", "Horror", Convert.ToDateTime("2005/05/14"), "Someone", 4.5, "A nice game", "url", "url", 1, 1);
			Game game6 = new Game(6, "Amsterdam2", "Horror", Convert.ToDateTime("2005/05/14"), "Someone", 5, "A nice game", "url", "url", 2, 1);

			Review review1 = new Review(1, "Nicole", "url", "4", "Best game ever!", 1, 1);
			Review review2= new Review(2, "Nicole", "url", "5", "Best game ever!", 6, 2);
			
            List<Game> testData = new List<Game> { game1, game2, game3, game4, game5, game6 };
			List<Review> testReviews = new List<Review> { review1, review2 };
            List<Game> recommendations = new List<Game>();

            recommendations = gamesService.GetRecommendations(testData, testReviews, "Horror");

            Assert.AreEqual(recommendations.Count, 0);

		}


	}
}