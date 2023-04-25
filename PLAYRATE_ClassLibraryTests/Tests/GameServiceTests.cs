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
            string releaseDate = "14/05/2020";
            string genre = "Fantasy";
            string rating = "4";
            string desc = "A very long description";
            string urlGame = "url";
            string urlPage = "url";

            gamesService.AddGame(id, name, genre, releaseDate, developer, rating, desc, urlGame, urlPage);

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    SqlCommand createGame = new SqlCommand($"SELECT * FROM dbo.{console}", con);
            //    SqlDataReader reader = createGame.ExecuteReader();
            //    Assert.IsTrue(reader.HasRows);
            //    reader.Read();
            //    con.Close();
            //}
        }

        [TestMethod()]
        public void RemoveGameTest()
        {
            string name = "Something";

            gamesService.RemoveGame(name);

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    SqlCommand removeGame = new SqlCommand($"SELECT * FROM dbo.{console}", con);
            //    SqlDataReader reader = removeGame.ExecuteReader();
            //    Assert.IsTrue(reader.HasRows);
            //    reader.Read();
            //    con.Close();
            //}
        }

        [TestMethod()]
        public void GetAllTest()
        {

            gamesService.GetAll();

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    SqlCommand getAll = new SqlCommand($"SELECT * FROM dbo.{console}", con);
            //    SqlDataReader reader = getAll.ExecuteReader();
            //    Assert.IsTrue(reader.HasRows);
            //    reader.Read();
            //    con.Close();
            //}
        }

        [TestMethod()]
        public void GetGameTest()
        {
            string name = "Something";

            gamesService.GetGame(name);

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    SqlCommand getGame = new SqlCommand($"SELECT * FROM dbo.{console}", con);
            //    SqlDataReader reader = getGame.ExecuteReader();
            //    Assert.IsTrue(reader.HasRows);
            //    reader.Read();
            //    con.Close();
            //}
        }

        //[TestMethod()]
        //public void GetByGenreTest()
        //{
        //    string genre = "Fantasy";
        //    string console = "Playstation5";

        //    gamesService.GetByGenre(genre, console);

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();
        //        SqlCommand getByGenre = new SqlCommand($"SELECT * FROM dbo.{console}", con);
        //        SqlDataReader reader = getByGenre.ExecuteReader();
        //        Assert.IsTrue(reader.HasRows);
        //        reader.Read();
        //        con.Close();
        //    }
        //}

        //[TestMethod()]
        //public void GetByKeywordTest()
        //{
        //    string keyword = "Som";
        //    string console = "Playstation5";

        //    gamesService.GetByKeyword(keyword, console);

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();
        //        SqlCommand getByKeyword = new SqlCommand($"SELECT * FROM dbo.{console}", con);
        //        SqlDataReader reader = getByKeyword.ExecuteReader();
        //        Assert.IsTrue(reader.HasRows);
        //        reader.Read();
        //        con.Close();
        //    }
        //}

        //[TestMethod()]
        //public void GetByMainFilterTest()
        //{
        //    string filter = "Highest rating";
        //    string console = "Playstation5";

        //    gamesService.GetByMainFilter(filter, console);

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();
        //        SqlCommand getByMainFilter = new SqlCommand($"SELECT * FROM dbo.{console}", con);
        //        SqlDataReader reader = getByMainFilter.ExecuteReader();
        //        Assert.IsTrue(reader.HasRows);
        //        reader.Read();
        //        con.Close();
        //    }
        //}
    }
}