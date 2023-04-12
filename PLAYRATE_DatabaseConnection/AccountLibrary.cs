using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection
{
	public class AccountLibrary
	{

		public void AddAccount(string submittedEmail, string submittedUsername, string submittedPassword, string salt)
		{
			using (SqlConnection connection = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr"))
			{
				connection.Open();

				SqlCommand getMaxID = new SqlCommand("SELECT COALESCE(MAX(ID), 0) FROM dbo.Accounts", connection);

				int currentMaxID = (int)getMaxID.ExecuteScalar();

				int newID = currentMaxID + 1;

				SqlCommand cmd = new SqlCommand("INSERT into dbo.Accounts VALUES (@ID, @Email, @Username, @Password, @Salt)", connection);

				cmd.Parameters.AddWithValue("@ID", newID);
				cmd.Parameters.AddWithValue("@Email", submittedEmail);
				cmd.Parameters.AddWithValue("@Username", submittedUsername);
				cmd.Parameters.AddWithValue("@Password", submittedPassword);
				cmd.Parameters.AddWithValue("@Salt", salt);

				cmd.ExecuteNonQuery();
			}
		}

		public void RemoveAccount(int id)
		{
			using (SqlConnection connection = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr"))
			{
				connection.Open();

				SqlCommand cmd = new SqlCommand($"DELETE from dbo.Accounts WHERE ID = '{id}'", connection);

				cmd.ExecuteNonQuery();
			}
		}

		public string GetUsernameFromEmail(string email)
		{
			using (SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr"))
			{
				con.Open();

				string query = $"SELECT Username FROM dbo.Accounts WHERE Email='{email}'";
				SqlCommand command = new SqlCommand(query, con);

				return command.ExecuteScalar().ToString();
			}
		}

		public SqlDataReader GetAccountLogIn(string email)
		{
			SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID=dbi499630;Password=Jvm5cNGGkr");

			con.Open();

			string query = $"SELECT Password, Salt FROM dbo.Accounts WHERE Email='{email}'";
			SqlCommand command = new SqlCommand(query, con);
			SqlDataReader reader = command.ExecuteReader();

			return reader;
		}


		public string GenerateSalt()
		{
			byte[] salt = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}
			return Convert.ToBase64String(salt);
		}

		public string HashPassword(string password)
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
