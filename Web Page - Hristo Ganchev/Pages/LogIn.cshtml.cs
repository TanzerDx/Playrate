using BusinessLogic;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Text;

namespace Home_Page___Hristo_Ganchev.Pages
{
	public class LogInModel : PageModel
    {

		public string PageTitle { get; private set; }

		public string LogInResult { get; private set; }

        public string Username { get; private set; }

        public string SubmittedEmail { get; private set; }
		
		public string SubmittedPassword { get; private set; }

		private const string pepper = "iloveplayrate";

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
			SubmittedEmail = LogIn.GetEmail();
			SubmittedPassword = LogIn.GetPassword();

			using (SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr"))
			{
				con.Open();

				string query = $"SELECT Password, Salt FROM dbo.Accounts WHERE Email='{SubmittedEmail}'";
				SqlCommand command = new SqlCommand(query, con);
				SqlDataReader reader = command.ExecuteReader();

				if (reader.Read())
				{
					string storedHashedPassword = reader.GetString(0);
					string salt = reader.GetString(1);

					string saltedPassword = $"{SubmittedPassword}{salt}{pepper}";
					string hashedPassword = HashPassword(saltedPassword);

					if (hashedPassword == storedHashedPassword)
					{
						Username = GetUsernameFromEmail(SubmittedEmail);
						HttpContext.Session.SetString("Username", Username);
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

		private string GetUsernameFromEmail(string email)
		{
			using (SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr"))
			{
				con.Open();

				string query = $"SELECT Username FROM dbo.Accounts WHERE Email='{email}'";
				SqlCommand command = new SqlCommand(query, con);

				return command.ExecuteScalar().ToString();
			}
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

