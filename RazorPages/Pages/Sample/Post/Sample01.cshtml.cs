using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.Post
{
    public class Sample01 : PageModel
    {
        public string Name { get; set; }
        
        public void OnPost(string name)
        {
            Name = name;
        }
    }
}