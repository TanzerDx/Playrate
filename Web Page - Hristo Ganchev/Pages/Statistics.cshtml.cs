using FluentResults;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PLAYRATE_ClassLibrary.Games;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class StatisticsModel : PageModel
    {
        GameService gameService;

        public Result<List<Game>> StatisticsHighestRating { get; private set; }

        public Result<List<Game>> StatisticsMostReviews { get; private set; }

        public StatisticsModel(GameService gS)
        {
            gameService = gS;
		}

        public IActionResult OnGet()
        {
			StatisticsHighestRating = gameService.GetStatistics("highestRating");
			StatisticsMostReviews = gameService.GetStatistics("mostReviews");

			return Page();
        }
    }
}
