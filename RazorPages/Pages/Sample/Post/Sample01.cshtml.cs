using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.Post
{
    public class Sample01 : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        
        public void OnPost()
        {
        }
    }
}