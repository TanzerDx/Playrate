using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Console = PLAYRATE_ClassLibrary.Consoles.Console;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class ConsolesPageModel : PageModel
    {
        private readonly ILogger<ConsolesPageModel> _logger;

        private IConsoleService _consoleService;

        public string UserName { get; private set; }

        public string PageTitle { get; private set; }

        public ConsolesPageModel(ILogger<ConsolesPageModel> logger)
        {
            PageTitle = "CONSOLES:";
            _logger = logger;
            _consoleService = new ConsoleService();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public List<Console> Consoles
        {
            get { return _consoleService.GetAll(); }
        }

        public void OnPost()
        {

        }
    }
}
