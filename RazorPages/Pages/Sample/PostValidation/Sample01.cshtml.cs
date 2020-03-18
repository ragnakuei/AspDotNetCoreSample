using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.PostValidation
{
    public class Sample01 : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Required Field !!")]
        [StringLength( 60, MinimumLength = 2)]
        public string Name { get; set; }

        public void OnGet()
        {
        }
        
        public void OnPost()
        {
        }
    }
}