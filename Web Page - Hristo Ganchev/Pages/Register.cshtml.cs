using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class RegisterModel : PageModel
    {
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

				SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");
				con.Open();
				SqlCommand cmd = new SqlCommand("INSERT into dbo.Accounts VALUES (@ID, @Email, @Username, @Password)", con);

				cmd.Parameters.AddWithValue("@ID", 1);
				cmd.Parameters.AddWithValue("@Email", SubmittedEmail);
				cmd.Parameters.AddWithValue("@Username", SubmittedUsername);
				cmd.Parameters.AddWithValue("@Password", SubmittedPassword);

				cmd.ExecuteNonQuery();

				con.Close();

			}
		}
	}
}

