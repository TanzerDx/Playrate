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
            if (gameService.StatisticsHighestRating().IsSuccess && gameService.StatisticsMostReviews().IsSuccess)
            {
                StatisticsHighestRating = gameService.StatisticsHighestRating();
                StatisticsMostReviews = gameService.StatisticsMostReviews();

                return Page();
            }
            else
            {
                return Redirect("/Error");
            }
        }
    }
}
