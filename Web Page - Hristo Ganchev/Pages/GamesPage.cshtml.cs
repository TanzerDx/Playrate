using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Page___Hristo_Ganchev
{
    public class GamesPageModel : PageModel
    {

        public string PageTitle { get; private set; }

        public string SubmittedKeyword { get; private set; }

        public string SubmittedMainFilter { get; private set; }

        public string SubmittedGenreFilter { get; private set; }


        [BindProperty]
        public Filter Filter { get; set; }

        public GamesPageModel()
        {
            PageTitle = "GAMES:";
        }

        public void OnGet()
        {

        }


        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                SubmittedKeyword = $"{Filter.GetKeyword()}";
				SubmittedMainFilter = $"{Filter.GetMainFilter()}";
                SubmittedGenreFilter = $"{Filter.GetGenreFilter()}";

			}
        }
    }
}
