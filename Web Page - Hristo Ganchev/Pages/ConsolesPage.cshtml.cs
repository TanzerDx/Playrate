using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Console = PLAYRATE_ClassLibrary.Consoles.Console;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class ConsolesPageModel : PageModel
    {
        private readonly ILogger<ConsolesPageModel> _logger;

        ConsoleService consoleLibrary;

        public string UserName { get; private set; }

        public string PageTitle { get; private set; }

        public ConsolesPageModel(ILogger<ConsolesPageModel> logger, ConsoleService consoleService)
        {
            PageTitle = "CONSOLES:";
            _logger = logger;
            consoleLibrary = consoleService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public List<Console> Consoles
        {
            get { return consoleLibrary.GetAll(); }
        }

        public void OnPost()
        {

        }
    }
}
