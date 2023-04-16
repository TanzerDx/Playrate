using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection.Tests
{
	[TestClass()]
	public class AccountLibraryTests
	{
		private readonly string connectionString = "Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID=dbi499630;Password=Jvm5cNGGkr";
		AccountLibrary accountLibrary = new AccountLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID=dbi499630;Password=Jvm5cNGGkr");

        private const string pepper = "iloveplayrate";
		public string salt;
		public string hashedPassword;

        [TestMethod()]
		public void AddAccountTest()
		{

			string submittedEmail = "hristoganchev@gmail.com";
			string submittedUsername = "HristoG";
			string submittedPassword = "1234567890";

            string Salt = GenerateSalt();
            string saltedPassword = $"{submittedPassword}{Salt}{pepper}";
            hashedPassword = HashPassword(saltedPassword);

            accountLibrary.AddAccount(submittedEmail, submittedUsername, hashedPassword, Salt);

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