namespace Home_Page___Hristo_Ganchev.wwwroot.css
{
    public class FilterFormModel : PageModel
    {
        public string PageTitle { get; set; }

        [BindProperty]
        public Filter Filter { get; set; }

        public FilterFormModel() 
        { 
            PageTitle = "GAMES:";
        }

        public void OnGet()
        {

        }

        public void OnPost()
        { 
        
        }
    }
}
