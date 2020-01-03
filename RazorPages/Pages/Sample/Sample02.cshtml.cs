using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample
{
    public class Sample02 : PageModel
    {
        public string Message { get; set; } = "Initial Request";
    
        // 可有可無
        public void OnGet()
        {
            
        }
    }
}