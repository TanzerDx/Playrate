﻿using PLAYRATE_ClassLibrary.Games;
using System;
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

		public List<Game> ApplyFilter(string? keyword, string? mainFilter, string? genre, List<Game> games)
		{
			games = games.Where(game => game.Genre == genre).OrderByDescending(game => game.Rating).ToList();
			return games;
		}

    }
}
