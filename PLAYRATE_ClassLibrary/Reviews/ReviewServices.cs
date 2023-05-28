using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Reviews
{
    public class ReviewServices : IReviewServices
    {
        private const string _connectionString = "Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr";
        private readonly IReviewRepository _reviewLibrary;

        public ReviewServices(IReviewRepository _reviewLibrary)
        {
            this._reviewLibrary = _reviewLibrary;
        }

        public Result<List<Review>> GetReviews(int? gameID, int? consoleID)
        {
            try
            { 
                List<Review> reviews = _reviewLibrary.GetReviews(gameID, consoleID).Select(dto => dto.ToReview()).ToList();
                return reviews;
            }
			catch (Exception exception)
			{
				return Result.Fail(new Error("Unable to retrieve reviews!").CausedBy(exception));
			}
}


        public void AddReview(string Username, string URL_ProfilePicture, string Rating, string ReviewDesc, int? gameID, int? consoleID)
        {
            try
            {
                _reviewLibrary.AddReview(Username, URL_ProfilePicture, Rating,ReviewDesc, gameID, consoleID);
            }
			catch (Exception exception)
			{
				Result.Fail(new Error("Unable to add rating!").CausedBy(exception));
			}
}
        
        public Result<int?> GetNumberOfReviews(string username)
        {
            try
            { 
                Result<int?> numberReviews = _reviewLibrary.GetNumberOfReviews(username);
                return numberReviews;
            }
			catch (Exception exception)
			{
				return Result.Fail(new Error("Unable to get number of reviews!").CausedBy(exception));
			}
        }

        public Result<double?> GetRating(int? gameID, int? consoleID)
        {
            try
            { 
                double? numberReviews = _reviewLibrary.GetRating(gameID, consoleID);
                return numberReviews;
            }
			catch (Exception exception)
			{
				return Result.Fail(new Error("Unable to get rating!").CausedBy(exception));
			}
}
    }
}
