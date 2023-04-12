using System;
using System.Security.Cryptography;
using System.Text;
using BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PLAYRATE_DatabaseConnection;

namespace Home_Page___Hristo_Ganchev.Pages
{
	public class RegisterModel : PageModel
	{
		AccountLibrary accountLibrary = new AccountLibrary();

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
