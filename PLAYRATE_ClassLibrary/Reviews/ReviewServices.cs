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

        public List<Review> GetReviews(int gameID, int consoleID)
        {
            List<Review> reviews = _reviewLibrary.GetReviews(gameID, consoleID).Select(dto => dto.ToReview()).ToList();
            return reviews;
        }


        public void AddReview(string Username, string URL_ProfilePicture, string Rating, string ReviewDesc, int Game_ID, int Console_ID)
        {
            _reviewLibrary.AddReview(Username, URL_ProfilePicture, Rating,ReviewDesc, Game_ID, Console_ID);
        }

    }
}
