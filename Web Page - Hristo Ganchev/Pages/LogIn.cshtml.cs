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

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class LogInModel : PageModel
    {
        IAccountRepository accountRepository = new AccountLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");

        AccountService accountLibrary;

		public string PageTitle { get; private set; }

		public string LogInResult { get; private set; }

        public string Username { get; private set; }

		public string ProfilePicUser { get; private set; }

        public string SubmittedEmail { get; private set; }
		
		public string SubmittedPassword { get; private set; }

		private const string pepper = "iloveplayrate";

		[BindProperty]
		public LogIn LogIn { get; set; }

		public LogInModel()
		{
			PageTitle = "LOG IN:";
            accountLibrary = new AccountService(accountRepository);
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
				string storedHashedPassword = reader.GetString(0);
				string salt = reader.GetString(1);

				string saltedPassword = $"{SubmittedPassword}{salt}{pepper}";
				string hashedPassword = accountLibrary.HashPassword(saltedPassword);

				if (hashedPassword == storedHashedPassword)
				{
					Username = accountLibrary.GetUsernameFromEmail(SubmittedEmail);
					ProfilePicUser = accountLibrary.GetProfilePic(SubmittedEmail);
					
					HttpContext.Session.SetString("Username", Username);
					HttpContext.Session.SetString("Email", SubmittedEmail);
					HttpContext.Session.SetString("ProfilePicUser", ProfilePicUser);

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

