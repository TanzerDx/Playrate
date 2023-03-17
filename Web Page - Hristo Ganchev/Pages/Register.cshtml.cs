using Desktop_App___Hristo_Ganchev;
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
		public Register Register { get; set; }

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
				SubmittedEmail = $"{Register.GetEmail()}";
				SubmittedUsername = $"{Register.GetUsername()}";
				SubmittedPassword = $"{Register.GetPassword()}";

				Account account = new Account(SubmittedUsername, SubmittedEmail, SubmittedPassword);
				alm.AddAccount(account);

			}
		}
	}
}

