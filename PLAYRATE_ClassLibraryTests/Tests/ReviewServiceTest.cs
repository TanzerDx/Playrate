using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibrary.Reviews;
using PLAYRATE_ClassLibraryTests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibraryTests.Tests
{
	[TestClass()]
	public class ReviewServiceTest
	{
		ReviewServices reviewService;

		ReviewMockDatabase mock = new ReviewMockDatabase();

		public ReviewServiceTest()
		{
			reviewService = new ReviewServices(new MockReviewRepository());
		}
	}
}
