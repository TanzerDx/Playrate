using Home_Page___Hristo_Ganchev.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Home_Page___Hristo_Ganchev
{
    public class GamesPageModel : PageModel
    {
        private readonly ILogger<GamesPageModel> _logger;

        GameService gameService;

        public string UserName { get; private set; }

        public string PageTitle { get; private set; }

        public string? SubmittedKeyword { get; private set; }

        public string? SubmittedMainFilter { get; private set; }

        public string? SubmittedGenreFilter { get; private set; }

        public string Model { get; private set; }

        public List<Game> Games { get; private set; }


        [BindProperty]
        public BusinessLogic.Filter Filter { get; set; }

        public GamesPageModel(ILogger<GamesPageModel> logger, GameService gS)
        {
            PageTitle = "GAMES:";
            _logger = logger;
            gameService = gS;
            Games = new List<Game>();
        }

        public IActionResult OnGet(string model)
        {
            Model = model;
            Games = gameService.GetAll(model);
            //gameService.SetRating(model);

            return Page();
        }

        public void OnPost()
        {
            SubmittedKeyword = $"{Filter.GetKeyword()}";
            SubmittedMainFilter = $"{Filter.GetMainFilter()}";
            SubmittedGenreFilter = $"{Filter.GetGenreFilter()}";

            switch ((SubmittedKeyword != "", SubmittedMainFilter != "", SubmittedGenreFilter != ""))
            {
                case (true, false, false):
                    Games = gameService.GetByKeyword(SubmittedKeyword, Model);
                    break;
                case (false, true, false):
                    Games = gameService.GetByMainFilter(SubmittedMainFilter, Model);
                    break;
                case (false, false, true):
                    Games = gameService.GetByGenre(SubmittedGenreFilter, Model);
                    break;
            }
        }
    }
}
