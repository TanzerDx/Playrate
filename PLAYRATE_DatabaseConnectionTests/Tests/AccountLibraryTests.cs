using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection.Tests
{
	[TestClass()]
	public class AccountLibraryTests
	{
		private readonly string connectionString = "Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID=dbi499630;Password=Jvm5cNGGkr";
		AccountLibrary accountLibrary = new AccountLibrary();

		[TestMethod()]
		public void AddAccountTest()
		{
			string submittedEmail = "hristoganchev@gmail.com";
			string submittedUsername = "HristoG";
			string submittedPassword = "1234567890";

			accountLibrary.AddAccount(submittedEmail, submittedUsername, submittedPassword);

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				SqlCommand createAccount = new SqlCommand($"SELECT * FROM dbo.Accounts", con);
				SqlDataReader reader = createAccount.ExecuteReader();
				Assert.IsTrue(reader.HasRows);
				reader.Read();
				con.Close();
			}
		}

		[TestMethod()]
		public void RemoveAccountTest()
		{
			int id = 2;

			accountLibrary.RemoveAccount(id);

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				SqlCommand deleteAccount = new SqlCommand($"SELECT * FROM dbo.Accounts", con);
				SqlDataReader reader = deleteAccount.ExecuteReader();
				Assert.IsTrue(reader.HasRows);
				reader.Read();
				con.Close();
			}
		}
	}
}