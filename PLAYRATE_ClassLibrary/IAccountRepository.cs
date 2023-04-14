using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace PLAYRATE_ClassLibrary
{
    public interface IAccountRepository
    {
        void AddAccount(string submittedEmail, string submittedUsername, string submittedPassword, string salt);

        void RemoveAccount(int id);

        string GetUsernameFromEmail(string email);

        SqlDataReader GetAccountLogIn(string email);
    }
}
