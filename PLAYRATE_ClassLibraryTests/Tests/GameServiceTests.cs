using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_ClassLibrary.Games;
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
        private readonly string connectionString = "Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID=dbi499630;Password=Jvm5cNGGkr";
        IGameRepository gamesRepository = new GamesLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");
        GameService gamesService;

        public GameServiceTests()
        {
            gamesService = new GameService(gamesRepository);
        }

        [TestMethod()]
        public void AddGameTest()
        {
            string console = "Playstation5";
            string name = "Something";
            string developer = "Developer";
            string releaseDate = "14/05/2020";
            string genre = "Fantasy";
            string rating = "4";
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";

            gamesService.AddGame(console, name, developer, releaseDate, genre, rating, desc, urlGame, urlPage);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand createGame = new SqlCommand($"SELECT * FROM dbo.{console}", con);
                SqlDataReader reader = createGame.ExecuteReader();
                Assert.IsTrue(reader.HasRows);
                reader.Read();
                con.Close();
            }
        }

        [TestMethod()]
        public void RemoveGameTest()
        {
            string console = "Playstation5";
            string id = "1";

            gamesService.RemoveGame(console, id);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand removeGame = new SqlCommand($"SELECT * FROM dbo.{console}", con);
                SqlDataReader reader = removeGame.ExecuteReader();
                Assert.IsTrue(reader.HasRows);
                reader.Read();
                con.Close();
            }
        }

        [TestMethod()]
        public void GetAllTest()
        {
            string console = "Playstation5";

            gamesService.GetAll(console);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand getAll = new SqlCommand($"SELECT * FROM dbo.{console}", con);
                SqlDataReader reader = getAll.ExecuteReader();
                Assert.IsTrue(reader.HasRows);
                reader.Read();
                con.Close();
            }
        }

        [TestMethod()]
        public void GetGameTest()
        {
            string name = "Something";
            string console = "Playstation5";

            gamesService.GetGame(name, console);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand getGame = new SqlCommand($"SELECT * FROM dbo.{console}", con);
                SqlDataReader reader = getGame.ExecuteReader();
                Assert.IsTrue(reader.HasRows);
                reader.Read();
                con.Close();
            }
        }

        [TestMethod()]
        public void GetByGenreTest()
        {
            string genre = "Fantasy";
            string console = "Playstation5";

            gamesService.GetByGenre(genre, console);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand getByGenre = new SqlCommand($"SELECT * FROM dbo.{console}", con);
                SqlDataReader reader = getByGenre.ExecuteReader();
                Assert.IsTrue(reader.HasRows);
                reader.Read();
                con.Close();
            }
        }

        [TestMethod()]
        public void GetByKeywordTest()
        {
            string keyword = "Som";
            string console = "Playstation5";

            gamesService.GetByKeyword(keyword, console);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand getByKeyword = new SqlCommand($"SELECT * FROM dbo.{console}", con);
                SqlDataReader reader = getByKeyword.ExecuteReader();
                Assert.IsTrue(reader.HasRows);
                reader.Read();
                con.Close();
            }
        }

        [TestMethod()]
        public void GetByMainFilterTest()
        {
            string filter = "Highest rating";
            string console = "Playstation5";

            gamesService.GetByMainFilter(filter, console);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand getByMainFilter = new SqlCommand($"SELECT * FROM dbo.{console}", con);
                SqlDataReader reader = getByMainFilter.ExecuteReader();
                Assert.IsTrue(reader.HasRows);
                reader.Read();
                con.Close();
            }
        }
    }
}