using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.PostValidation
{
    public class Sample03 : PageModel
    {
        public PostValidationSample03Model ValidationModel { get; set; }

        public void OnGet()
        {
            ValidationModel = new PostValidationSample03Model();
        }
        
        /// <remarks>
        /// 這個方式可用於 MVC ，但 RazorPage 目前不支援
        /// </remarks>
        public IActionResult OnPost(PostValidationSample03Model t)
        {
            if(t.Name.Length < 2)
            {
                ModelState.AddModelError( nameof(PostValidationSample03Model.Name), "Name MinimumLength is 2" );
            }
            
            ValidationModel = t;
            return Page();
        }
    }

    public class PostValidationSample03Model
    {
        [Required]
        [StringLength( 60, MinimumLength = 2)]
        public string Name { get; set; }
    }
}