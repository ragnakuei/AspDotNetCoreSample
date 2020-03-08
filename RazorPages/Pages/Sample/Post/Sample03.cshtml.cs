using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.Post
{
    public class Sample03 : PageModel
    {
        public string Name { get; set; }
        
        public void OnPost()
        {
            Name = Request.Form["name"];
        }
    }
}