using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibraryTests.Repositories
{
	public class MockReviewRepository : IReviewRepository
	{
		public List<ReviewDTO> GetReviews(int? gameID, int? consoleID)
		{
			throw new NotImplementedException();
		}

		public void AddReview(string Username, string URL_ProfilePicture, string Rating, string ReviewDesc, int? Game_ID, int? Console_ID)
		{
			throw new NotImplementedException();
		}

		public int? GetNumberOfReviews(string username)
		{
			throw new NotImplementedException();
		}

		public double? GetRating(int? gameID, int? consoleID)
		{
			throw new NotImplementedException();
		}
	}
}
