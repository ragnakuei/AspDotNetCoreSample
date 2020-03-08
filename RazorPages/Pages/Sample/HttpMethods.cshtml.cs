using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample
{
    public class HttpMethods : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Get";
        }

        public void OnPost()
        {
            Message = "Post";
        }

        public void OnDelete()
        {
            Message = "Delete";
        }

        public void OnPut()
        {
            Message = "Put";
        }

        public void OnPatch()
        {
            Message = "Patch";
        }
    }
}