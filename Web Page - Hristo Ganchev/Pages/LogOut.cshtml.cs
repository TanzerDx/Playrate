using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class LogOutModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Remove("Username");
            Response.Redirect("/LogIn");
        }
    }
}
