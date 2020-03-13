using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.Routing
{
    public class Parameter : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        
        public void OnGet()
        {
            
        }
    }
}