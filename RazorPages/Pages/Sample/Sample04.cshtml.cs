using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample
{
    public class Sample04 : PageModel
    {
        public int PageNo { get; set; }
        
        public int PageSize { get; set; }
        
        public void OnGet(int pageNo, int pageSize)
        {
            PageNo = pageNo;
            PageSize = pageSize;
        }
    }
}