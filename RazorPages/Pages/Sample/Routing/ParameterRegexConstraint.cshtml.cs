using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.Routing
{
    public class ParameterRegexConstraint : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        
        public void OnGet()
        {
            
        }
    }
}