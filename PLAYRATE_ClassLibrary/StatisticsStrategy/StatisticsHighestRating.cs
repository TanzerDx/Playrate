using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.StatisticsStrategy
{
	public class StatisticsHighestRating : IStatisticsStrategy
	{
		public bool ShouldApply(string desiredStatistic)
		{
			if (desiredStatistic == "highestRating") 
			{
				return true;
			}
			return false;
		}

		public List<Game> Apply(List<Game> games)
		{
			games = games.OrderByDescending(game => game.Rating).Take(5).ToList();
			return games;
		}
	}
}
