using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace BusinessLogic
{
    public class Filter
    {
        public Filter()
        { }

        public string? Keyword { get; set; }

        public string? MainFilter { get; set; }

        public string? GenreFilter { get; set; }

        public Filter(string keyword, string mainFilter, string genreFilter)
        {
            Keyword = keyword;
            MainFilter = mainFilter;
            GenreFilter = genreFilter;
        }

        public string GetKeyword()
        {
            return Keyword;
        }

        public string GetMainFilter() 
        { 
            return MainFilter;
        }

        public string GetGenreFilter()
        {
            return GenreFilter;
        }
    }

}