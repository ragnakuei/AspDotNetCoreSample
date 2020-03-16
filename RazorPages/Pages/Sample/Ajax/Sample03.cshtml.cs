using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.Ajax
{
    public class Sample03 : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnGetPartial()
        {
            Thread.Sleep(2000);
            return new PartialViewResult
            {
                ViewName = "_HelloWorldPartial",
                ViewData = this.ViewData
            };
        }
    }
}