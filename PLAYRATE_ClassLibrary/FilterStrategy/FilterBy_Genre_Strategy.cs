using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.FilterStrategy
{
    public class FilterBy_Genre_Strategy : IFilterStrategy
    {
		public bool ShouldApply(string keyword, string mainFilter, string genre)
		{
			if (keyword == "" && mainFilter == "" && genre != "")
			{
				return true;
			}
			return false;
		}

		public SqlCommand ApplyFilter(SqlConnection connection, string? keyword, string? mainFilter, string? genre, string console)
        {
            SqlCommand sqlCommand = new SqlCommand($"select * from dbo.{console} where Genres = '{genre}'", connection);
            return sqlCommand;
        }
    }
}
