using FluentResults;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Accounts
{
    public interface IAccountService
    {
        void AddAccount(string submittedEmail, string submittedUsername, Result<string> hashedPassword, Result<string> salt);

        void RemoveAccount(int id);

        Result<Account> GetAccount(string email);

        Result<string> GetUsernameFromEmail(string email);

        Result<string> GetProfilePic(string email);

        SqlDataReader GetAccountLogIn(string email);

        Result<string> GenerateSalt();

        Result<string> HashPassword(string password);
    }
}
