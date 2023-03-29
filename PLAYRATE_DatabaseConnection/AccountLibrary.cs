using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection
{
	public class AccountLibrary
	{

		public void AddAccount(string submittedEmail, string submittedUsername, string submittedPassword)
		{
			using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False"))
			{
				connection.Open();

				SqlCommand getMaxID = new SqlCommand("SELECT COALESCE(MAX(ID), 0) FROM dbo.Accounts", connection);

				int currentMaxID = (int)getMaxID.ExecuteScalar();

				int newID = currentMaxID + 1;

				SqlCommand cmd = new SqlCommand("INSERT into dbo.Accounts VALUES (@ID, @Email, @Username, @Password)", connection);

				cmd.Parameters.AddWithValue("@ID", newID);
				cmd.Parameters.AddWithValue("@Email", submittedEmail);
				cmd.Parameters.AddWithValue("@Username", submittedUsername);
				cmd.Parameters.AddWithValue("@Password", submittedPassword);

				cmd.ExecuteNonQuery();
			}
		}
	}
}
