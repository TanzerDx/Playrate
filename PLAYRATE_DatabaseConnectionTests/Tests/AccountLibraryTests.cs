using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection.Tests
{
	[TestClass()]
	public class AccountLibraryTests
	{
		AccountLibrary accountLibrary = new AccountLibrary();

		[TestMethod()]
		public void AddAccountTest()
		{
			string submittedEmail = "hristoganchev@gmail.com";
			string submittedUsername = "HristoG";
			string submittedPassword = "1234567890";

			accountLibrary.AddAccount(submittedEmail, submittedUsername, submittedPassword);
		}

		[TestMethod()]
		public void RemoveAccountTest()
		{
			int id = 2;

			accountLibrary.RemoveAccount(id);
		}
	}
}