using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.StatisticsStrategy
{
	public interface IStatisticsStrategy
	{
		public bool ShouldApply(string desiredStatisic);
		public List<Game> Apply(List<Game> games);

	}
}
