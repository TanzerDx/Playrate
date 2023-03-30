using Home_Page___Hristo_Ganchev.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PLAYRATE_ClassLibrary.Games;
using System.Reflection;
using System.Xml.Linq;

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

        public string Model { get; private set; }

        public List<Game> Games { get; private set; }


        [BindProperty]
        public BusinessLogic.Filter Filter { get; set; }

        public GamesPageModel(ILogger<GamesPageModel> logger)
        {
            PageTitle = "GAMES:";
            _logger = logger;
            _gameService = new GameService();
        }

        public IActionResult OnGet(string model)
        {
            Model = model;
            Games = _gameService.GetAll(model);

            return Page();
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
