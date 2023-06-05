using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.FilterStrategy
{
    public interface IFilterStrategy
    {
        bool ShouldApply(string keyword, string mainFilter, string genre);
        public List<Game> ApplyFilter(string? keyword, string? mainFilter, string? genre, List<Game> games);

	}
}
