using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibraryTests
{
	internal class MockGameRepository : IGameRepository
	{
		public void AddGame(string console, string name, string developer, DateTime releaseDate, string genre, string desc, string urlGame, string urlPage, int? consoleID)
		{
			throw new NotImplementedException();
		}

		public void CalculateNumberOfReviews(int? consoleID, int? gameID, string console)
		{
			throw new NotImplementedException();
		}

		public List<GameDTO> GetAll(string console)
		{
			throw new NotImplementedException();
		}

		public List<GameDTO> GetAllGames()
		{
			throw new NotImplementedException();
		}

		public GameDTO? GetGame(string name, string console)
		{
			throw new NotImplementedException();
		}

		public int? GetGameID(string console, string name)
		{
			throw new NotImplementedException();
		}

		public List<GameDTO> GetRecommendations(string username, double minimum, double maximum)
		{
			throw new NotImplementedException();
		}

		public void RemoveGame(string console, string tbID)
		{
			throw new NotImplementedException();
		}

		public void SetRating(int? consoleID, int? gameID, string console)
		{
			throw new NotImplementedException();
		}
	}
}
