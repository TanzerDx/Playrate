using Home_Page___Hristo_Ganchev.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PLAYRATE_ClassLibrary.Games;

namespace Home_Page___Hristo_Ganchev
{
    public class GamesPageModel : PageModel
    {
        private readonly ILogger<GamesPageModel> _logger;

        private IGameService _gameService;

        public string UserName { get; private set; }

        public string PageTitle { get; private set; }

        public string SubmittedKeyword { get; private set; }

        public string SubmittedMainFilter { get; private set; }

        public string SubmittedGenreFilter { get; private set; }

        public string Console { get; private set; }

        [BindProperty]
        public BusinessLogic.Filter Filter { get; set; }

        public GamesPageModel(ILogger<GamesPageModel> logger)
        {
            PageTitle = "GAMES:";
            _logger = logger;
            _gameService = new GameService();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public List<Game> Games
        {
            get { return _gameService.GetAll("XboxONE"); }
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                SubmittedKeyword = $"{Filter.GetKeyword()}";
				SubmittedMainFilter = $"{Filter.GetMainFilter()}";
                SubmittedGenreFilter = $"{Filter.GetGenreFilter()}";

			}
        }
    }
}
