using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_DatabaseConnection.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection.Games.Tests
{
	[TestClass()]
	public class GamesLibraryTests
	{
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

		}

		[TestMethod()]
		public void RemoveGameTest()
		{
			string console = "Playstation5";
			string id = "1";

			gamesLibrary.RemoveGame(console, id);

		}

		[TestMethod()]
		public void GetAllTest()
		{
			string console = "Playstation4";

			gamesLibrary.GetAll(console);
		}

		[TestMethod()]
		public void GetGameTest()
		{
			string name = "Something";
			string console = "Playstation5";

			gamesLibrary.GetGame(name, console);
			
		}

		[TestMethod()]
		public void GetByGenreTest()
		{
			string genre = "Fantasy";
			string console = "Playstation5";

			gamesLibrary.GetByGenre(genre, console);
		}

		[TestMethod()]
		public void GetByKeywordTest()
		{
			string keyword = "Som";
			string console = "Playstation5";

			gamesLibrary.GetByKeyword(keyword, console);
		}

		[TestMethod()]
		public void GetByMainFilterTest() 
		{
			string filter = "Highest rating";
			string console = "Playstation5";

			gamesLibrary.GetByMainFilter(filter, console);
		}
	}
}