using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection.FilterStrategy
{
    public interface IFilterStrategy
    {
        SqlCommand ApplyFilter(SqlConnection connection, string? keyword, string? mainFilter, string? genre, string console);
    }
}
