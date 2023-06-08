using BusinessLogic;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Text;
using PLAYRATE_ClassLibrary.Accounts;
using PLAYRATE_ClassLibrary;
using PLAYRATE_DatabaseConnection;
using FluentResults;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class LogInModel : PageModel
    {
		AccountService accountLibrary;

		public string PageTitle { get; private set; }

		public string LogInResult { get; private set; }

        public Result<string> Username { get; private set; }

		public Result<string> ProfilePicUser { get; private set; }

        public string SubmittedEmail { get; private set; }
		
		public string SubmittedPassword { get; private set; }

		private const string pepper = "iloveplayrate";

		[BindProperty]
		public LogIn LogIn { get; set; }

		public LogInModel(AccountService accountService)
		{
			PageTitle = "LOG IN:";
            accountLibrary = accountService;
        }

		public void OnGet()
		{

		}

		public void OnPost()
		{
			SubmittedEmail = LogIn.GetEmail();
			SubmittedPassword = LogIn.GetPassword();

			SqlDataReader reader = accountLibrary.GetAccountLogIn(SubmittedEmail) ;

			if (reader.Read())
			{
				Result<string> storedHashedPassword = reader.GetString(0);
				string salt = reader.GetString(1);

				string saltedPassword = $"{SubmittedPassword}{salt}{pepper}";
				Result<string> hashedPassword = accountLibrary.HashPassword(saltedPassword).Value;

				if (hashedPassword.Value == storedHashedPassword.Value)
				{
					Username = accountLibrary.GetUsernameFromEmail(SubmittedEmail);
					ProfilePicUser = accountLibrary.GetProfilePic(SubmittedEmail);
					
					HttpContext.Session.SetString("Username", Username.Value.ToString());
					HttpContext.Session.SetString("Email", SubmittedEmail);
					HttpContext.Session.SetString("ProfilePicUser", ProfilePicUser.Value.ToString());

					Response.Redirect("/ProfilePage");
				}
				else
				{
					LogInResult = "Invalid email or password.";
				}
			}
			else
			{
				LogInResult = "Invalid email or password.";
			}

		}

	}
}

