using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Home_Page___Hristo_Ganchev
{
    public class Filter
    {
        public Filter()
        { }

        public string Keyword { get; set; }

        public Filter(string keyword)
        {
            Keyword = keyword;
        }

        public string GetKeyword()
        {
            return Keyword;
        }
    }
}