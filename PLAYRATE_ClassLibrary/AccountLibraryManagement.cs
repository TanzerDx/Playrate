using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE
{
	public class AccountLibraryManagement
	{
		List<Account> allAccounts = new List<Account>();

		public void AddAccount(Account a)
		{
			allAccounts.Add(a);
		}


		public Account GetAccount(string name)
		{
			Account account = null;
			foreach (Account a in allAccounts)
			{
				if (name == a.GetName())
				{
					account = a;
					break;
				}
			}
			return account;
		}

	
		public List<Account> GetAllAccounts()
		{
			return allAccounts;
		}

	}
}

