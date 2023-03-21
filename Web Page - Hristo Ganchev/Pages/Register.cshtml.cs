using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class RegisterModel : PageModel
    {
		AccountLibraryManagement alm = new AccountLibraryManagement();
		public string PageTitle { get; private set; }

		public string SubmittedEmail { get; private set; }

		public string SubmittedUsername { get; private set; }

		public string SubmittedPassword { get; private set; }


		[BindProperty]
		public Account Account { get; set; }

		public RegisterModel()
		{
			PageTitle = "REGISTER:";
		}

		public void OnGet()
		{

		}


		public void OnPost()
		{
			if (ModelState.IsValid)
			{
				SubmittedEmail = $"{Account.GetEmail()}";
				SubmittedUsername = $"{Account.GetName()}";
				SubmittedPassword = $"{Account.GetPassword()}";

				Account account = new Account(SubmittedUsername, SubmittedEmail, SubmittedPassword);
				alm.AddAccount(account);

			}
		}
	}
}

