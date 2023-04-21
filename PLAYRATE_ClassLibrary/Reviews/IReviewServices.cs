using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Reviews
{
    public interface IReviewServices
    {
        List<Review> GetReviews(int gameID, int consoleID);

        void AddReview(string Username, string URL_ProfilePicture, string Rating, string ReviewDesc, int Game_ID, int Console_ID);
    }
}
