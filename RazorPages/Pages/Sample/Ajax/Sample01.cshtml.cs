using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.Ajax
{
    public class Sample01 : PageModel
    {
        public void OnGet()
        {
            
        }

        [BindProperty]
        public string Name { get; set; }
        public IActionResult OnPost()
        {
            return Content(Name);
        }
    }
}