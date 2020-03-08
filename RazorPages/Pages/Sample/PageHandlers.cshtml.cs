using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample
{
    public class PageHandlers : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Get";
        }

        public void OnPost()
        {
            Message = "Form Posted";
        }

        public void OnPostDelete()
        {
            Message = "Delete handler fired";
        }

        public void OnPostEdit()
        {
            Message = "Edit handler fired";
        }

        public void OnPostView()
        {
            Message = "View handler fired";
        }
    }
}