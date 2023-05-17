using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

		[Required, Range(0, 5, ErrorMessage = "The rating must be between 0 and 5.")]
		public string Rating { get; init; }

		[Required, MinLength(10, ErrorMessage = "The review should be at least 10 characters!")]
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
