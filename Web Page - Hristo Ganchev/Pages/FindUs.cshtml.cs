using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Page___Hristo_Ganchev.Pages
{
	public class FindUsModel : PageModel
	{
		public string PageTitle { get; private set; }
		public string SuccessfulSubmission { get; private set; }
		public string? SubjectText { get; private set; }

		[BindProperty]
		public Contact Contact { get; set; }

		public FindUsModel()
		{
			PageTitle = "FIND US:";
		}

		public void OnGet()
		{

		}

		public void OnPost()
		{
			if (ModelState.IsValid)
			{
				SuccessfulSubmission = $"Hello {Contact.GetName()}, thank you for contacting us! We will respond within 2 working days to {Contact.GetEmail()}";
			}

			ModelState.Clear();
		}

	}
}

