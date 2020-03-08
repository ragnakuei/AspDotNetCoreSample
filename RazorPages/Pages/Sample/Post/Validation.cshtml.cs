using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.Post
{
    public class Validation : PageModel
    {
        public ValidationModel ValidationModel { get; set; }
        
        public void OnPost(ValidationModel t)
        {
            ValidationModel = t;
        }
    }

    public class ValidationModel
    {
        [Required]
        [StringLength( 60, MinimumLength = 2)]
        public string Name { get; set; }
    }
}