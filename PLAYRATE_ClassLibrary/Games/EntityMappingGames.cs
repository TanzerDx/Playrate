using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Games
{
    public static class EntityMappingGames
	{
		public static Game ToGame(this GameDTO gameDTO)
		{
			return new Game()
			{
				ID = gameDTO.ID,
				Name = gameDTO.Name,
				Developer = gameDTO.Developer,
				Release_Date = gameDTO.Release_Date,
				Genre = gameDTO.Genre,
				Rating = gameDTO.Rating.ToString(),
				Description = gameDTO.Description,
				URL_Game = gameDTO.URL_Game,
				URL_Page = gameDTO.URL_Page
			};
		}

		public static GameDTO ToGameDTO(this Game game)
		{
			return new GameDTO()
			{
				ID = game.ID,
				Name = game.Name,
				Developer = game.Developer,
				Release_Date = game.Release_Date,
				Genre = game.Genre,
				Rating = Convert.ToDouble(game.Rating),
				Description = game.Description,
				URL_Game = game.URL_Game,
				URL_Page = game.URL_Page
			};
		}
	}
}
