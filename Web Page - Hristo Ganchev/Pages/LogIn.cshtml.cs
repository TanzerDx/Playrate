using BusinessLogic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Home_Page___Hristo_Ganchev.Pages
{
	public class LogInModel : PageModel
    {

		public string PageTitle { get; private set; }

		public string LogInResult { get; private set; }

        public string Username { get; private set; }

        public string SubmittedEmail { get; private set; }
		
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
			SubmittedEmail = LogIn.GetEmail();
			SubmittedPassword = LogIn.GetPassword();

			SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");

			string query = $"SELECT COUNT (*) FROM dbo.Accounts WHERE Email='{SubmittedEmail}' AND Password='{SubmittedPassword}'";
			string getName = $"SELECT Username FROM dbo.Accounts WHERE Email='{SubmittedEmail}' AND Password='{SubmittedPassword}'";

            con.Open();
			
			SqlCommand command = new SqlCommand(query, con);

            int v = (int)command.ExecuteScalar();

            if (v != 1)
				{
					LogInResult = "Invalid email or password.";
					return;
				}
				else
				{
                SqlCommand command2 = new SqlCommand(getName, con);
                Username = command2.ExecuteScalar().ToString();

                HttpContext.Session.SetString("Username", Username);
                Response.Redirect("/ProfilePage");
				}

			
		}
	}
}

