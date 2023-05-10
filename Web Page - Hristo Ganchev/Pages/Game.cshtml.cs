using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibrary.Reviews;
using PLAYRATE_DatabaseConnection;
using System;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class GameModel : PageModel
    {
        private readonly ILogger<GameModel> _logger;

        GameService gameService;

        ReviewServices reviewService;

        ConsoleService consoleService;

        public GameModel(ILogger<GameModel> logger, GameService gS, ReviewServices rS, ConsoleService cS)
        {
            _logger = logger;
            gameService = gS;
            reviewService = rS;
            consoleService = cS;
        }

        public string Name{ get; private set; }

        public string Model { get; private set; }

        public string Username { get; private set; }

        public string ProfilePicUser { get; private set; }

        public int? GameID { get; private set; }

        public int? ConsoleID { get; private set; }

        public string SubmittedRating { get; set; }

        public string SubmittedReviewDesc { get; set; }

        public Game Game { get; private set; }

        public PLAYRATE_ClassLibrary.Consoles.Console Console { get; private set; }

        [BindProperty]
        public Review Review { get; set; }

        public List<Review> Reviews { get; set; }

        public IActionResult OnGet(string name, string model)
        {
            Name = name;
            Model = model;
            ConsoleID = consoleService.GetConsoleID(model);
            GameID = gameService.GetGameID(model, name);    
            Reviews = reviewService.GetReviews(GameID, ConsoleID);
            Game = gameService.GetGame(name , model);
            Username = HttpContext.Session.GetString("Username");
            ProfilePicUser = HttpContext.Session.GetString("ProfilePicUser");

            HttpContext.Session.SetString("Name", Name);
            HttpContext.Session.SetString("Model", Model);
            

            return Page();
        }

        public void OnPost()
        {
                Name = HttpContext.Session.GetString("Name");
                Model = HttpContext.Session.GetString("Model");
                Username = HttpContext.Session.GetString("Username");
                ProfilePicUser = HttpContext.Session.GetString("ProfilePicUser");

                ConsoleID = consoleService.GetConsoleID(Model);
                GameID = gameService.GetGameID(Model, Name);
                Reviews = reviewService.GetReviews(GameID, ConsoleID);
                Game = gameService.GetGame(Name, Model);

                SubmittedRating = Review.Rating;
                SubmittedReviewDesc = Review.ReviewDesc;
                reviewService.AddReview(Username, ProfilePicUser, SubmittedRating, SubmittedReviewDesc, ConsoleID, GameID);
                gameService.SetRating(ConsoleID, GameID, Model);
                Response.Redirect("/ThankYou");
        }

    }
}
