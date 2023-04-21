using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibrary.Reviews;
using PLAYRATE_DatabaseConnection;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class GameModel : PageModel
    {
        private readonly ILogger<GameModel> _logger;

        IGameRepository gamesRepository = new GamesLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");
        GameService gameService;

        IReviewRepository reviewRepository = new ReviewLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");
        ReviewServices reviewService;

        public GameModel(ILogger<GameModel> logger)
        {
            _logger = logger;
            gameService = new GameService(gamesRepository);
            reviewService = new ReviewServices(reviewRepository);
        }

        public string Name{ get; private set; }

        public string Model { get; private set; }

        public string SubmittedRating { get; set; }

        public string SubmittedReviewDesc { get; set; }

        public Game Game { get; private set; }

        [BindProperty]
        public Review Review { get; set; }

        public List<Review> Reviews { get; set; }

        public void OnGet(string name, string model)
        {
            Name = name;
            Model = model;
            Reviews = reviewService.GetReviews(1, 1);
            Game = gameService.GetGame(name , "Playstation4");
        }

        public void OnPost()
        {
            SubmittedRating = Review.Rating;
            SubmittedReviewDesc = Review.ReviewDesc;
        }

    }
}
