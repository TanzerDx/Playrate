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
		SqlCommand ApplyFilter(SqlConnection connection, string? keyword, string? mainFilter, string? genre, string console);
    }
}
