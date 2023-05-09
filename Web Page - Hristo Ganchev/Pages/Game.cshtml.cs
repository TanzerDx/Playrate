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

        public static double? Rating { get; private set; }

        public static string Username { get; private set; }

        public static string ProfilePicUser { get; private set; }

        public static int? GameID { get; private set; }

        public static int? ConsoleID { get; private set; }

        public string SubmittedRating { get; set; }

        public string SubmittedReviewDesc { get; set; }

        public static Game Game { get; private set; }

        public PLAYRATE_ClassLibrary.Consoles.Console Console { get; private set; }

        [BindProperty]
        public Review Review { get; set; }

        public static List<Review> Reviews { get; set; }

        public void OnGet(string name, string model)
        {
            Name = name;
            Model = model;
            ConsoleID = consoleService.GetConsoleID(model);
            GameID = gameService.GetGameID(model, name);    
            Reviews = reviewService.GetReviews(GameID, ConsoleID);
            Game = gameService.GetGame(name , model);
            Rating = reviewService.GetRating(GameID, ConsoleID);
            Username = HttpContext.Session.GetString("Username");
            ProfilePicUser = HttpContext.Session.GetString("ProfilePicUser");
        }

        public void OnPost()
        {
                SubmittedRating = Review.Rating;
                SubmittedReviewDesc = Review.ReviewDesc;
                reviewService.AddReview(Username, ProfilePicUser, SubmittedRating, SubmittedReviewDesc, ConsoleID, GameID);
                Response.Redirect("/ThankYou");
        }

    }
}
