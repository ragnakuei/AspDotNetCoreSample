using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample
{
    public class QueryString : PageModel
    {
        public int PageNo { get; set; }
        
        public void OnGet(int pageNo)
        {
            PageNo = pageNo;
        }
    }
}