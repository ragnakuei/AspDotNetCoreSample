using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.Post
{
    public class Sample02 : PageModel
    {
        public string Name { get; set; }
        
        public void OnPost(string name)
        {
            Name = name;
        }
    }
}