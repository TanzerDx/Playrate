using BusinessLogic;
using FluentResults;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibrary.Reviews;
using PLAYRATE_ClassLibraryTests;
using PLAYRATE_ClassLibraryTests.Repositories;
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
		GameService gamesService;

		GameMockDatabase mock = new GameMockDatabase();

		public GameServiceTests()
		{
			gamesService = new GameService(new MockGameRepository());
		}

		[TestMethod]
		public void Filter()
		{

			List<Game> testData = mock.GetMockDatabase();
			List<Game> filteredData;


			// Filter by All Test
			filteredData = gamesService.Filter("Something", "Highest rating", "Fantasy", testData).Value;
			Assert.AreEqual(filteredData[0].Name, "Something");


			// Filter by Keyword Test
			filteredData = gamesService.Filter("Another", "", "", testData).Value;
			Assert.AreEqual(filteredData.Count, 1);
			Assert.AreEqual(filteredData[0].Name, "Another");


			// Filter by Main Filter Test
			filteredData = gamesService.Filter("", "Highest rating", "", testData).Value;
			Assert.AreEqual(filteredData[0].Name, "Fontys");


			// Filter by Genre
			filteredData = gamesService.Filter("", "", "Fantasy", testData).Value;
			Assert.AreEqual(filteredData.Count, 2);


			// Filter by Main Filter and Keyword Test
			filteredData = gamesService.Filter("Another", "Highest rating", "", testData).Value;
			Assert.AreEqual(filteredData.Count, 1);


			// Filter by Keyword and Genre
			filteredData = gamesService.Filter("Hello", "", "Sci-Fi", testData).Value;
			Assert.AreEqual(filteredData.Count, 1);


			// Filter by Main Filter and Genre
			filteredData = gamesService.Filter("", "Highest rating", "Fantasy", testData).Value;
			Assert.AreEqual(filteredData[0].Name, "Another");
		}


		[TestMethod]
        public void GetRecommendations()
        {
            List<Game> recommendations;

            recommendations = gamesService.GetRecommendations("Jacob", 4, 5).Value;

            Assert.AreEqual(recommendations[0].Name, "Just Cause 2");

		}


	}
}