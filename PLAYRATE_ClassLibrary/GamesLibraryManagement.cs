using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE
{
	public class GamesLibraryManagement
	{
		List<Game> allGames = new List<Game>();


		public void AddGame(Game g)
		{
			allGames.Add(g);
		}

		public void RemoveGame(Game g)
		{
			allGames.Remove(g);
		}


		public Game GetGame(string name)
		{
			Game game = null;
			foreach (Game g in allGames)
			{
				if (name == g.GetName())
				{
					game = g;
					break;
				}
			}
			return game;
		}

		public List<Game> GetAllGames()
		{
			return allGames;
		}
	}
}

