using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Dto;

namespace RazorPages.Pages.Order
{
    public class List : PageModel
    {
        [BindProperty]
        public OrderDto Order { get; set; }
        
        
        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}