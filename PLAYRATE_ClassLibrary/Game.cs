using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PLAYRATE.ClassLibrary
{
    public class Game
    {
        List<Review> reviews = new List<Review>();

        string name;
        string description;
        Genres genre;
        string releaseDate;
        string developer;
        string rating;

        public Game(string name, string description, Genres genre, string releaseDate, string developer, string rating)
        {
            this.name = name;
            this.description = description;
            this.genre = genre;
            this.releaseDate = releaseDate;
            this.developer = developer;
            this.rating = rating;
        }

        public void AddReview(Review r)
        {
            this.reviews.Add(r);
        }

        public List<Review> GetAllReviews()
        {
            return this.reviews;
        }

        public string GetName()
        {
            return name;
        }

        public string GetDesc()
        {
            return description;
        }

        public Genres GetGenre()
        {
            return genre;
        }

        public string GetReleaseDate()
        {
            return releaseDate;
        }

        public string GetDeveloper()
        {
            return developer;
        }

        public string GetRating()
        {
            return rating;
        }

    }
}
