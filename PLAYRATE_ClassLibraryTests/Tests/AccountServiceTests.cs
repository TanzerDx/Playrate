using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_ClassLibrary.Accounts;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibraryTests;
using PLAYRATE_ClassLibraryTests.Repositories;
using PLAYRATE_DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Accounts.Tests
{
    [TestClass()]
    public class AccountServiceTests
    {
		AccountService accountService;

		AccountMockDatabase mock = new AccountMockDatabase();

		public AccountServiceTests()
		{
			accountService = new AccountService(new MockAccountRepository());
		}
	}
}