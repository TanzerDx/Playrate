using PLAYRATE_ClassLibrary.Accounts;
using PLAYRATE_ClassLibrary.Consoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibraryTests
{
    public class AccountMockDatabase
    {
		public List<Account> GetMockDatabase()
		{
			Account account1 = new Account(1, "url", "salt", "Amanda", "amanda@gmail.com", "iloveplayrate");
			Account account2 = new Account(2, "url", "salt", "Adam", "adam@gmail.com", "iloveplayrate");
			Account account3 = new Account(3, "url", "salt", "John", "john@gmail.com", "iloveplayrate");
			Account account4 = new Account(4, "url", "salt", "Simon", "simon@gmail.com", "iloveplayrate");
			Account account5 = new Account(5, "url", "salt", "George", "george@gmail.com", "iloveplayrate");

			List<Account> accounts = new List<Account> { account1, account2, account3, account4, account5 };

			return accounts;
		}
	}
}
