using PLAYRATE_ClassLibrary.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibraryTests
{
    public class ReviewMockDatabase
    {
		public List<Review> GetMockDatabase()
		{
			Review review1 = new Review(1, "Amanda", "url", "4.5", "Its a very good game!", 1 , 1);
			Review review2 = new Review(2, "John", "url", "5", "Best game ever!", 2, 1);
			Review review3 = new Review(3, "Adam", "url", "4", "The game is perfect, excluding the voice acting.", 3, 1);
			Review review4 = new Review(4, "Simon", "url", "2", "I do not recommend it...", 4, 1);
			Review review5 = new Review(5, "George", "url", "1", "This game is awful!!!", 5, 1);

			List<Review> reviews = new List<Review> { review1, review2, review3, review4, review5 };

			return reviews;
		}
	}
}
