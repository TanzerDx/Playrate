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

				Salt = GenerateSalt();

				string saltedPassword = $"{SubmittedPassword}{Salt}{pepper}";
				HashedPassword = HashPassword(saltedPassword);

				accountLibrary.AddAccount(SubmittedEmail, SubmittedUsername, HashedPassword, Salt);
			}
		}

		private string GenerateSalt()
		{
			byte[] salt = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}
			return Convert.ToBase64String(salt);
		}

		private string HashPassword(string password)
		{
			byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(password);
			byte[] hashBytes;
			using (var algorithm = new Rfc2898DeriveBytes(password, saltedPasswordBytes, 10000, HashAlgorithmName.SHA512))
			{
				hashBytes = algorithm.GetBytes(32);
			}
			return Convert.ToBase64String(hashBytes);
		}
	}
}
