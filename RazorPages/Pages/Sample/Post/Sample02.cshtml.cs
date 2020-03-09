using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample.Post
{
    public class Sample02 : PageModel
    {
        public string Name { get; set; }
        
        /// <remarks>
        /// 這個方式不建議用
        /// </remarks>
        public void OnPost(string name)
        {
            Name = name;
        }
    }
}