﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.FilterStrategy
{
    public class FilterBy_MainFilter_Strategy : IFilterStrategy
    {
		public bool ShouldApply(string keyword, string mainFilter, string genre)
		{
			if (keyword == "" && mainFilter != "" && genre == "")
			{
				return true;
			}
			return false;
		}

		public SqlCommand ApplyFilter(SqlConnection connection, string? keyword, string? mainFilter, string? genre, string console)
        {
            string order = GetOrderBy(mainFilter, console);
            SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM dbo.{console} ORDER BY {order}", connection);
            return sqlCommand;
        }

        private string GetOrderBy(string? mainFilter, string console)
        {
            string? order = null;

            switch (mainFilter)
            {
                case "Highest rating":
                    order = "Rating DESC";
                    break;

                case "Latest release":
                    order = "Release_Date DESC";
                    break;

                case "Most reviews":
                    order = "Reviews DESC";
                    break;
            }

            return order;
        }
    }

}