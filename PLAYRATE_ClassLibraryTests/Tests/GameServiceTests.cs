using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_ClassLibrary.Consoles;
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
		GameService gamesService;

		GameMockDatabase mock = new GameMockDatabase();

		public GameServiceTests()
		{
			//IGameRepository gameRepository = new GamesLibrary("Data Source = mssqlstud.fhict.local; Persist Security Info = True; User ID = dbi499630; Password = Jvm5cNGGkr");
			gamesService = new GameService(new MockGameRepository());
		}

		[TestMethod()]
		public void Filter()
		{
			List<Game> testData;

            testData = mock.GetMockDatabase();

            testData = gamesService.Filter("Another", "Highest rating", "Fantasy", testData).Value;

            Assert.AreEqual(testData[0].Name, "Another");

		}

        [TestMethod()]
        public void GetRecommendations()
        {
            List<Game> recommendations;

            recommendations = gamesService.GetRecommendations("Jacob", 4, 5).Value;

            Assert.AreEqual(recommendations[0].Name, "Just Cause 2");

		}


	}
}