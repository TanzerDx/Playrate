using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Games
{
    public class GameService : IGameService
    {   
        private readonly IGameRepository _gamesLibrary;

        public GameService(IGameRepository _gamesLibrary)
        {
            this._gamesLibrary = _gamesLibrary;
        }

        public List<Game> GetAll(string console)
        {
            //try
            //{
                var games = _gamesLibrary.GetAll(console).Select(dto => dto.ToGame()).ToList();
                return games;
			//}
   //         catch
   //         {

   //         }

		}

        public Game GetGame(string name, string console)
        {
            //try
            //{
                var gameDTO = _gamesLibrary.GetGame(name, console);
                return gameDTO.Value.ToGame();
		    //}
      //      catch
      //      {

      //      }
        }

        public int? GetGameID(string console, string name)
        {
			//try
			//{
			    int? gameID = _gamesLibrary.GetGameID(console, name);
                return gameID;
		    //}
      //      catch
      //      {

      //      }
        }

        public List<Game> Filter(string? keyword, string? mainFilter, string? genre, string console)
        {
            //try
            //{
                var games = _gamesLibrary.Filter(keyword, mainFilter, genre, console).Select(dto => dto.ToGame()).ToList();
                return games;
		 //   }
   //         catch
   //         {
			//}
        }

        public List<Game> GetRecommendations(string username)
        {
            //try
            //{ 
                var games = _gamesLibrary.GetRecommendations(username).Select(dto => dto.ToGame()).ToList();
                return games;
		    //}
      //      catch
      //      {
      //      }
        }

        public void AddGame(string console, string name, string developer, DateTime releaseDate, string genre, string desc, string urlGame, string urlPage, int? consoleID)
        {
            try
            {
                _gamesLibrary.AddGame(console, name, developer, releaseDate, genre, desc, urlGame, urlPage, consoleID);
		    }
            catch
            {
            }
        }

        public void RemoveGame(string console, string tbID)
        {
            try 
            {
                _gamesLibrary.RemoveGame(console, tbID);
		    }
            catch
            {
            }
        }

        public void SetRating(int? consoleID, int? gameID, string console)
        {
            try
            { 
                _gamesLibrary.SetRating(consoleID, gameID, console);
		    }
            catch
            {
            }
        }

        public void CalculateNumberOfReviews(int? consoleID, int? gameID, string console)
        {
            try
            {
                _gamesLibrary.CalculateNumberOfReviews(consoleID, gameID, console);
		    }
            catch
            {
            }
        }
    }
}
