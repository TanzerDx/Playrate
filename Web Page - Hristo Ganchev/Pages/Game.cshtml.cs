using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class GameModel : PageModel
    {
        private readonly ILogger<GameModel> _logger;

        IGameRepository gamesRepository = new GamesLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");
        
        GameService gameService;

        public GameModel(ILogger<GameModel> logger)
        {
            _logger = logger;
            gameService = new GameService(gamesRepository);
        }

        public string Name{ get; private set; }

        public string Model { get; private set; }

        public Game Game { get; private set; }

        public void OnGet(string name, string model)
        {
            Name = name;
            Model = model;
            Game = gameService.GetGame(name , "Playstation4");
        }

    }
}
