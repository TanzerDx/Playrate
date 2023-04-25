﻿using PLAYRATE_ClassLibrary.Consoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibraryTests
{
    public class AccountMockDatabase
    {
        List<PLAYRATE_ClassLibrary.Accounts.Account> accounts = new List<PLAYRATE_ClassLibrary.Accounts.Account>();

        public void AddAccount(string username, string email, string password)
        {
            PLAYRATE_ClassLibrary.Accounts.Account account = new PLAYRATE_ClassLibrary.Accounts.Account(username, email, password);
            accounts.Add(account);
        }

        public void RemoveAccount(string email)
        {
            foreach (PLAYRATE_ClassLibrary.Accounts.Account a in accounts)
            {
                if (a.Email == email)
                {
                    accounts.Remove(a);
                }
            }
        }
    }
}
