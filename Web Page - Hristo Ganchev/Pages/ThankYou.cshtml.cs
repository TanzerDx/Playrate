using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class ThankYouModel : PageModel
    {
        public void OnPost()
        {
            Response.Redirect("/ConsolesPage");
        }
    }
}
