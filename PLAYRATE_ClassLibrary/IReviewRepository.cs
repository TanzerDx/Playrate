using PLAYRATE_ClassLibrary.Reviews;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary
{
    public interface IReviewRepository
    {
        List<ReviewDTO> GetReviews(int? gameID, int? consoleID);

        void AddReview(string Username, string URL_ProfilePicture, string Rating, string ReviewDesc, int? Game_ID, int? Console_ID);

        int? GetNumberOfReviews(string username);
    }
}
