using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Accounts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibraryTests.Repositories
{
	public class MockAccountRepository: IAccountRepository
	{
		public void AddAccount(string submittedEmail, string submittedUsername, string hashedPassword, string salt)
		{
			throw new NotImplementedException();
		}

		public void RemoveAccount(int id)
		{
			throw new NotImplementedException();
		}

		public AccountDTO? GetAccount(string email)
		{
			throw new NotImplementedException();
		}

		public string GetUsernameFromEmail(string email)
		{
			throw new NotImplementedException();
		}

		public string GetProfilePic(string email)
		{
			throw new NotImplementedException();
		}

		public SqlDataReader GetAccountLogIn(string email)
		{
			throw new NotImplementedException();
		}
	}
}
