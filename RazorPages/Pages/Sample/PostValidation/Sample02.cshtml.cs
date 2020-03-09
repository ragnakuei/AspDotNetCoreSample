using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.PostValidation
{
    public class Sample02 : PageModel
    {
        [BindProperty]
        public PostValidationSample02Model ValidationModel { get; set; }

        public void OnGet()
        {
            ValidationModel = new PostValidationSample02Model();
        }
        
        public void OnPost()
        {
        }
    }

    public class PostValidationSample02Model
    {
        [Required]
        [StringLength( 60, MinimumLength = 2)]
        public string Name { get; set; }
    }
}