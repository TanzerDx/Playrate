using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Reviews
{
    public class Review
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string URL_ProfilePicture { get; set; }

        public string Rating { get; set; }

        public string ReviewDesc{ get; set; }

        public string Game_ID { get; set; }

        public string Account_ID { get; set; }

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
