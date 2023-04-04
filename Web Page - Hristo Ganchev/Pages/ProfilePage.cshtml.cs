using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class ProfilePageModel : PageModel
    {
        public string Username { get; set; }

        public void OnGet()
        {
           Username = HttpContext.Session.GetString("Username")!;
        }
    }
}
