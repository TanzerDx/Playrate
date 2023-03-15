using Desktop_App___Hristo_Ganchev;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Page___Hristo_Ganchev.Pages
{
    public class LogInModel : PageModel
    {
		public string PageTitle { get; private set; }
		public string SuccessfulSubmission { get; private set; }
		public string? SubjectText { get; private set; }

		[BindProperty]
		public Contact Contact { get; set; }

		public LogInModel()
		{
			PageTitle = "LOG IN:";
		}

		public void OnGet()
		{

		}

		public void OnPost()
		{
			if (ModelState.IsValid)
			{
				Account account = new Account("", "", "");
			}

			ModelState.Clear();
		}

	}
}

