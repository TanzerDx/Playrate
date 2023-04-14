using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Accounts
{
    public class AccountService : IAccountService
    {
        private const string _connectionString = "Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr";
        private readonly IAccountRepository _accountsLibrary;

        public AccountService(IAccountRepository _accountsLibrary)
        {
            this._accountsLibrary = _accountsLibrary;
        }

        public void AddAccount(string submittedEmail, string submittedUsername, string submittedPassword, string salt)
        {
            _accountsLibrary.AddAccount(submittedEmail, submittedUsername, submittedPassword, salt);
        }

        public void RemoveAccount(int id)
        {
            _accountsLibrary.RemoveAccount(id);
        }

        public string GetUsernameFromEmail(string email)
        {
            string username = _accountsLibrary.GetUsernameFromEmail(email);
            return username;
        }

        public SqlDataReader GetAccountLogIn(string email)
        {
            SqlDataReader reader = _accountsLibrary.GetAccountLogIn(email);
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
