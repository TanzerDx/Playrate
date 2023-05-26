using FluentResults;
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
        Result<List<Review>> GetReviews(Result<int?> gameID, Result<int?> consoleID);

        void AddReview(string Username, string URL_ProfilePicture, string Rating, string ReviewDesc, Result<int?> gameID, Result<int?> consoleID);

        Result<int?> GetNumberOfReviews(string username);

        Result<double?> GetRating(Result<int?> gameID, Result<int?> consoleID);
    }
}
