using System;
using System.Security.Cryptography;
using System.Text;
using FluentResults;
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
        AccountService accountLibrary;

        public string PageTitle { get; private set; }

		public string SubmittedEmail { get; private set; }

		public string SubmittedUsername { get; private set; }

		public string SubmittedPassword { get; private set; }

		public Result<string> Salt { get; private set; } = string.Empty;

		public Result<string> HashedPassword { get; private set; } = string.Empty;

		private const string pepper = "iloveplayrate";

		[BindProperty]
		public Account Account { get; set; }

		public RegisterModel(AccountService aS)
		{
			PageTitle = "REGISTER:";
            accountLibrary = aS;
        }

		public void OnGet()
		{

		}

		public void OnPost()
		{
			try
			{
				SubmittedEmail = Account.GetEmail();
				SubmittedUsername = Account.GetName();
				SubmittedPassword = Account.GetPassword();

				Salt = accountLibrary.GenerateSalt();

				string saltedPassword = $"{SubmittedPassword}{Salt.Value}{pepper}";
				HashedPassword = accountLibrary.HashPassword(saltedPassword).Value;

				accountLibrary.AddAccount(SubmittedEmail, SubmittedUsername, HashedPassword.Value, Salt.Value);

				Response.Redirect("/LogIn");
			}
			catch
			{
				Response.Redirect("/Error");
			}
		}


	}
}
