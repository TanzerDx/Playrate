using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PLAYRATE_ClassLibrary.Games;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class RecommendationsModel : PageModel
    {
        private readonly ILogger<RecommendationsModel> _logger;

        GameService gameService;

        public string UserName { get; private set; }

        public List<Game> Games { get; private set; }


        [BindProperty]
        public BusinessLogic.Filter Filter { get; set; }

        public RecommendationsModel(ILogger<RecommendationsModel> logger, GameService gS)
        {
            _logger = logger;
            gameService = gS;
            Games = new List<Game>();
        }

        public IActionResult OnGet(string model)
        {
            string username = HttpContext.Session.GetString("Username");

            Games = gameService.GetRecommendations(username);

            return Page();
        }
    }
}
