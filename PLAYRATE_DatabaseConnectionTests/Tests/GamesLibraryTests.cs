using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_DatabaseConnection.Games;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection.Games.Tests
{
	[TestClass()]
	public class GamesLibraryTests
	{
		private readonly string connectionString = "Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID=dbi499630;Password=Jvm5cNGGkr";
		GamesLibrary gamesLibrary = new GamesLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID=dbi499630;Password=Jvm5cNGGkr");

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

			gamesLibrary.AddGame(console, name, developer, releaseDate, genre, rating, desc, urlGame, urlPage);

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				SqlCommand createGame = new SqlCommand($"SELECT * FROM dbo.{console}", con);
				SqlDataReader reader = createGame.ExecuteReader();
				Assert.IsTrue(reader.HasRows);
				reader.Read();
				//Assert.AreEqual(name, reader.GetString(1));
				//Assert.AreEqual(developer, reader.GetString(2));
				//Assert.AreEqual(releaseDate, reader.GetString(3));
				//Assert.AreEqual(genre, reader.GetString(4));
				//Assert.AreEqual(rating, reader.GetString(5));
				//Assert.AreEqual(desc, reader.GetString(6));
				//Assert.AreEqual(urlGame, reader.GetString(7));
				//Assert.AreEqual(urlPage, reader.GetString(8));
				con.Close();
			}

		}

		[TestMethod()]
		public void RemoveGameTest()
		{
			string console = "Playstation5";
			string id = "2";

			gamesLibrary.RemoveGame(console, id);

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
		public void GetAllTest()
		{
			string console = "Playstation5";

			gamesLibrary.GetAll(console);

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

			gamesLibrary.GetGame(name, console);

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

			gamesLibrary.GetByGenre(genre, console);

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

			gamesLibrary.GetByKeyword(keyword, console);

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

			gamesLibrary.GetByMainFilter(filter, console);

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