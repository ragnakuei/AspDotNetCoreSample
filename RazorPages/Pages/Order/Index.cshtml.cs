using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Order
{
    public class Index : PageModel
    {
        public string Message { get; private set; } = "PageModel in C#";

        public void OnGet()
        {
            Message += $" Server time is { DateTime.Now }";
        }

        [BindProperty]
        public string Test { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            Message += $" Server time is { DateTime.Now } Post";
            Test += "Z";
            return Page();
        }
    }
}