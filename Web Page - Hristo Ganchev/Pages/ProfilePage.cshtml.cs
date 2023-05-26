using FluentResults;
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

        AccountService accountService;
        ReviewServices reviewService;

        public Result<int?> NumberOfReviews { get; set; }

        public ProfilePageModel(ILogger<ProfilePageModel> logger, AccountService aS, ReviewServices rS)
        {
            _logger = logger;
            accountService = aS;
            reviewService = rS;
        }

        public Result<Account> Account { get; private set; }

        public void OnGet()
        {
          
            if (HttpContext.Session.GetString("Username") != null)
            {
                string username = HttpContext.Session.GetString("Username");
                Account = accountService.GetAccount(HttpContext.Session.GetString("Email")).Value;
                NumberOfReviews = reviewService.GetNumberOfReviews(username).Value;
            }
            else
            {
                Response.Redirect("/LogIn");
            }
        }
    }
}