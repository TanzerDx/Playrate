﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.FilterStrategy
{
    public class FilterBy_MainFilterAndGenre_Strategy : IFilterStrategy
    {
		public bool ShouldApply(string keyword, string mainFilter, string genre)
		{
			if (keyword == "" && mainFilter != "" && genre != "")
			{
				return true;
			}
			return false;
		}

		public SqlCommand ApplyFilter(SqlConnection connection, string? keyword, string? mainFilter, string? genre, string console)
        {
            string order = GetOrderBy(mainFilter);
            SqlCommand sqlCommand = new SqlCommand($"select * from dbo.{console} where Genres = '{genre}' ORDER BY {order}", connection);
            return sqlCommand;
        }

        private string GetOrderBy(string? mainFilter)
        {
            string? order = null;

            switch (mainFilter)
            {
                case "Highest rating":
                    {
                        order = "Rating DESC";
                        break;
                    }

                case "Latest release":
                    {
                        order = "Release_Date DESC";
                        break;
                    }

                case "Most reviews":
                    {
                        order = "Reviews DESC";
                        break;
                    }
            }

            return order;

        }
    }
}