using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Accounts;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibrary.Reviews;
using PLAYRATE_DatabaseConnection;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class ProfilePageModel : PageModel
    {
        private readonly ILogger<ProfilePageModel> _logger;

        IAccountRepository accountRepository = new AccountLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");
        AccountService accountService;

        public ProfilePageModel(ILogger<ProfilePageModel> logger)
        {
            _logger = logger;
            accountService = new AccountService(accountRepository);
        }

        public Account Account { get; private set; }

        public void OnGet()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                Account = accountService.GetAccount(HttpContext.Session.GetString("Email"));
            }
            else
            {
                Response.Redirect("/Error");
            }
        }
    }
}