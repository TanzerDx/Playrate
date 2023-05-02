﻿using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Reviews
{
    public static class EntityMappingReviews
    {
        public static Review ToReview(this ReviewDTO reviewDTO)
        {
            return new Review()
            {
                ID = reviewDTO.ID,

                Username = reviewDTO.Username,

                URL_ProfilePicture = reviewDTO.URL_ProfilePicture,

                Rating = reviewDTO.Rating,

                ReviewDesc = reviewDTO.ReviewDesc,

                Game_ID = reviewDTO.Game_ID,

                Account_ID = reviewDTO.Account_ID,
            };
        }

        public static ReviewDTO ToReviewDTO(this Review review)
        {
            return new ReviewDTO()
            {
                ID = review.ID,

                Username = review.Username,

                URL_ProfilePicture = review.URL_ProfilePicture,

                Rating = review.Rating,

                ReviewDesc = review.ReviewDesc,

                Game_ID = review.Game_ID,

                Account_ID = review.Account_ID,
            };
        }
    }
}