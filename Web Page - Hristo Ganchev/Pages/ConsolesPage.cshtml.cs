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

        IConsoleRepository consoleRepository = new ConsoleLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");
        
        ConsoleService consoleService;

        public string UserName { get; private set; }

        public string PageTitle { get; private set; }

        public ConsolesPageModel(ILogger<ConsolesPageModel> logger)
        {
            PageTitle = "CONSOLES:";
            _logger = logger;
            consoleService = new ConsoleService(consoleRepository);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public List<Console> Consoles
        {
            get { return consoleService.GetAll(); }
        }

        public void OnPost()
        {

        }
    }
}
