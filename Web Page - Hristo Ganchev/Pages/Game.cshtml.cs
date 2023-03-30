using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PLAYRATE_ClassLibrary.Games;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class GameModel : PageModel
    {
        private readonly ILogger<GameModel> _logger;

        private IGameService _gameService;

        public GameModel(ILogger<GameModel> logger)
        {
            _logger = logger;
            _gameService = new GameService();
        }

        public string Name{ get; private set; }

        public string Model { get; private set; }

        public Game Game { get; private set; }
        public void OnGet(string name, string model)
        {
            Name = name;
            Model = model;
            Game = _gameService.GetGame(name , "Playstation4");
        }

    }
}
