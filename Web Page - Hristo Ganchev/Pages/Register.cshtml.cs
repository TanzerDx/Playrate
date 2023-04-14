using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Accounts;
using PLAYRATE_DatabaseConnection;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class RegisterModel : PageModel
	{
        IAccountRepository accountRepository = new AccountLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");

        AccountService accountLibrary;

        public string PageTitle { get; private set; }

		public string SubmittedEmail { get; private set; }

		public string SubmittedUsername { get; private set; }

		public string SubmittedPassword { get; private set; }

		public string Salt { get; private set; } = string.Empty;

		public string HashedPassword { get; private set; } = string.Empty;

		private const string pepper = "iloveplayrate";

		[BindProperty]
		public Account Account { get; set; }

		public RegisterModel()
		{
			PageTitle = "REGISTER:";
            accountLibrary = new AccountService(accountRepository);
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

				Salt = accountLibrary.GenerateSalt();

				string saltedPassword = $"{SubmittedPassword}{Salt}{pepper}";
				HashedPassword = accountLibrary.HashPassword(saltedPassword);

				accountLibrary.AddAccount(SubmittedEmail, SubmittedUsername, HashedPassword, Salt);
			}
		}

	}
}
