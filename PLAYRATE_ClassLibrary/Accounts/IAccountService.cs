﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Accounts
{
    public interface IAccountService
    {
        void AddAccount(string submittedEmail, string submittedUsername, string submittedPassword, string salt);

        void RemoveAccount(int id);

        string GetUsernameFromEmail(string email);

        SqlDataReader GetAccountLogIn(string email);

        string GenerateSalt();

        string HashPassword(string password);
    }
}
