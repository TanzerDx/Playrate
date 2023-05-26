using FluentResults;
using PLAYRATE_ClassLibrary.Consoles;
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

        public void AddAccount(string submittedEmail, string submittedUsername, Result<string> hashedPassword, Result<string> salt)
        {
            try
            {
                _accountsLibrary.AddAccount(submittedEmail, submittedUsername, hashedPassword, salt);
            }
            catch (Exception exception)
            {
                Result.Fail(new Error("Unable to add account!").CausedBy(exception));
            }
        }

        public void RemoveAccount(int id)
        {
            try
            { 
                _accountsLibrary.RemoveAccount(id);
            }
			catch (Exception exception)
			{
				Result.Fail(new Error("Unable to remove account!").CausedBy(exception));
			}
}
        
        public Result<Account> GetAccount(string email) 
        {
            try
            { 
                var accountDTO = _accountsLibrary.GetAccount(email);
                return accountDTO.Value.ToAccount();
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to get account!").CausedBy(exception));
            }
        }
        public Result<string> GetUsernameFromEmail(string email)
        {
            try
            { 
                string username = _accountsLibrary.GetUsernameFromEmail(email);
                return username;
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to get username from email!").CausedBy(exception));
            }
        }

        public Result<string> GetProfilePic(string email)
        {
            try
            {
            string pfpURL = _accountsLibrary.GetProfilePic(email);
            return pfpURL;
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to get profile picture!").CausedBy(exception));
            }
        }

        public SqlDataReader GetAccountLogIn(string email)
        {
                SqlDataReader reader = _accountsLibrary.GetAccountLogIn(email);
                return reader;
        }

        public Result<string> GenerateSalt()
        {
            try
            {
            byte[] salt = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to generate salt!").CausedBy(exception));
            }
        }

        public Result<string> HashPassword(string password)
        {
            try
            {
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes;
                using (var algorithm = new Rfc2898DeriveBytes(password, saltedPasswordBytes, 10000, HashAlgorithmName.SHA512))
                {
                    hashBytes = algorithm.GetBytes(32);
                }
                return Convert.ToBase64String(hashBytes);
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to hash password!").CausedBy(exception));
            }
        }
    }
}
