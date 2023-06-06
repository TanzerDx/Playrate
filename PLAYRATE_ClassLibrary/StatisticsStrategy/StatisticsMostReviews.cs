using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.StatisticsStrategy
{
	public class StatisticsMostReviews : IStatisticsStrategy
	{
		public bool ShouldApply(string desiredStatistic)
		{
			if (desiredStatistic == "mostReviews")
			{
				return true;
			}
			return false;
		}

		public List<Game> Apply(List<Game> games)
		{
			games = games.OrderByDescending(game => game.Reviews).Take(5).ToList();
			return games;
		}
	}
}
