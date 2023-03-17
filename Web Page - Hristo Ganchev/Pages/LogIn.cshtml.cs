using Desktop_App___Hristo_Ganchev;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class LogInModel : PageModel
    {
		AccountLibraryManagement alm = new AccountLibraryManagement();

		Account account;

		public string PageTitle { get; private set; }

		public string LogInResult { get; private set; }

		public string SubmittedUsername { get; private set; }
		
		public string SubmittedPassword { get; private set; }

		[BindProperty]
		public LogIn LogIn { get; set; }

		public LogInModel()
		{
			PageTitle = "LOG IN:";
		}

		public void OnGet()
		{

		}

		public void OnPost()
		{
			if (ModelState.IsValid)
			{
				SubmittedUsername = $"{LogIn.GetUsername()}";
				SubmittedPassword = $"{LogIn.GetPassword()}";

				Account test = new Account("Hristo", "hristoganchev3@gmail.com", "123");
				alm.AddAccount(test);

				foreach (Account a in alm.GetAllAccounts())
				{

					if (SubmittedUsername == a.GetName() && SubmittedPassword == a.GetPassword())
					{
						account = a;

						Response.Redirect("/ProfilePage");

						break;
					}

					else
					{
						LogInResult = $"Wrong username or password!";
					}
				}
			}

			ModelState.Clear();
		}

	}
}

