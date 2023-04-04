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

		//public int LoggedInUser { get; private set; }

		public string LogInResult { get; private set; }

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

			SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");

			string query = $"SELECT COUNT (*) FROM dbo.Accounts WHERE Email='{SubmittedEmail}' AND Password='{SubmittedPassword}'";

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
					Response.Redirect("/ProfilePage");
				}

			
		}
	}
}

