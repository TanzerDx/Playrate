using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibrary.Reviews;
using PLAYRATE_DatabaseConnection;
using System.Text.Json.Serialization;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class GameModel : PageModel
    {
        private readonly ILogger<GameModel> _logger;

        IGameRepository gamesRepository = new GamesLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");
        GameService gameService;

        IReviewRepository reviewRepository = new ReviewLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");
        ReviewServices reviewService;

        IConsoleRepository consoleRepository = new ConsoleLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");
        ConsoleService consoleService;

        public GameModel(ILogger<GameModel> logger)
        {
            _logger = logger;
            gameService = new GameService(gamesRepository);
            reviewService = new ReviewServices(reviewRepository);
            consoleService = new ConsoleService(consoleRepository);
        }

        public string Name{ get; private set; }

        public string Model { get; private set; }

        public int? GameID { get; private set; }

        public int? ConsoleID { get; private set; }

        public string SubmittedRating { get; set; }

        public string SubmittedReviewDesc { get; set; }

        public Game Game { get; private set; }

        public PLAYRATE_ClassLibrary.Consoles.Console Console { get; private set; }

        [BindProperty]
        public Review Review { get; set; }

        public List<Review> Reviews { get; set; }

        public void OnGet(string name, string model)
        {
            Name = name;
            Model = model;
            ConsoleID = consoleService.GetConsoleID(model);
            GameID = gameService.GetGameID(model, name);    
            Reviews = reviewService.GetReviews(GameID, ConsoleID);
            Game = gameService.GetGame(name , model);
        }

        public void OnPost()
        {
            SubmittedRating = Review.Rating;
            SubmittedReviewDesc = Review.ReviewDesc;

            reviewService.AddReview("Maxwell", "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png", SubmittedRating, SubmittedReviewDesc, GameID, ConsoleID);
        }

    }
}
