using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Reviews
{
    public class Review
    {
        public int ID { get; init; }

        public string Username { get; init; }

        public string URL_ProfilePicture { get; init; }

        public string Rating { get; init; }

        public string ReviewDesc{ get; init; }

        public int Game_ID { get; init; }

        public int Account_ID { get; init; }

        public string GetRating()
        {
            return Rating;
        }

        public string GetReviewDesc()
        {
            return ReviewDesc;
        }

    }
}
