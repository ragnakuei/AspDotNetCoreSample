using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.Ajax
{
    public class Sample02 : PageModel
    {
        public void OnGet()
        {
            ViewData["Message"] = "(OnGet) Hi! ";
        }

        public IActionResult OnGetPartial()
        {
            ViewData["Message"] = "(OnGetPartial) Hi! ";
            
            // Partial View 的另一個用法
            return new PartialViewResult
            {
                ViewName = "_HelloWorldPartial",
                ViewData = this.ViewData,
                
                // ContentType = ,
                // StatusCode  = ,
                // TempData    = ,
                // ViewEngine  = ,
            };
        }
    }
}