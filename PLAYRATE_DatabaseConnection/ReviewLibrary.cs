using FluentResults;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibrary.Reviews;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection
{
    public class ReviewLibrary : IReviewRepository
    {
        private readonly string connectionString;

        public ReviewLibrary(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ReviewDTO> GetReviews(Result<int?> gameID, Result<int?> consoleID)
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from dbo.Reviews where Game_ID='{gameID.Value}' AND Console_ID='{consoleID.Value}'", con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ReviewDTO reviewDTO = CreateReviewDTO(reader);
                    reviews.Add(reviewDTO);
                }
                con.Close();
            }
            return reviews;
        }

        private ReviewDTO CreateReviewDTO(SqlDataReader reader)
        {
            return new ReviewDTO()
            {
                ID = reader.GetInt32(0),
                Username = reader.GetString(1),
                URL_ProfilePicture = reader.GetString(2),
                Rating = reader.GetDouble(3),
                ReviewDesc = reader.GetString(4),
                Game_ID = reader.GetInt32(5),
                Account_ID = reader.GetInt32(6),
            };
        }

        public void AddReview(string Username, string URL_ProfilePicture, string Rating, string ReviewDesc, Result<int?> Game_ID, Result<int?> Console_ID)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"INSERT into dbo.Reviews VALUES (@Username, @URL_ProfilePicture, @Rating, @ReviewDesc, @Game_ID, @Console_ID)", con);

                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@URL_ProfilePicture", URL_ProfilePicture);
                cmd.Parameters.AddWithValue("@Rating", Rating);
                cmd.Parameters.AddWithValue("@ReviewDesc", ReviewDesc);
                cmd.Parameters.AddWithValue("@Game_ID", Game_ID.Value);
                cmd.Parameters.AddWithValue("@Console_ID", Console_ID.Value);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public int? GetNumberOfReviews(string username)
        {
            int? numberReviews = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM dbo.Reviews WHERE Username = @Username", con);
                sqlCommand.Parameters.AddWithValue("@Username", username);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    numberReviews = reader.GetInt32(0);
                }
                con.Close();
            }
            return numberReviews;
        }


        public double? GetRating(Result<int?> gameID, Result<int?> consoleID)
        {
            double? rating = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT AVG(Rating) FROM dbo.Reviews WHERE Game_ID = '{gameID}' AND Console_ID = '{consoleID}'", con);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    try 
                    {
                    rating = reader.GetDouble(0);
                    }
                    catch
                    {
                        rating = 0;
                    }
                }
                con.Close();
            }
            return rating;
        }
    }
}
