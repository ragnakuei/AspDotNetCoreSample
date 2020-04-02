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

        public IActionResult OnPost(PostValidationSample03Model validationModel)
        {
            if (validationModel.Name?.Length < 2)
            {
                var propertyKey = $"{nameof(validationModel)}.{nameof(PostValidationSample03Model.Name)}";
                ModelState[propertyKey].Errors.Clear();
                ModelState.AddModelError(propertyKey, "Name MinimumLength is 2");
            }

            this.ValidationModel = validationModel;
            return Page();
        }
    }

    public class PostValidationSample03Model
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }
    }
}