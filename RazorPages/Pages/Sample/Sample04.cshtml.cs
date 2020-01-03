using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Sample
{
    public class Sample04 : PageModel
    {
        [BindProperty]
        public Order Order { get; set; }

        public IActionResult OnGet()
        {
            Order = new Order
                    {
                        OrderDetails = new OrderDetail[2]
                    };
            return Page();
        }
        
        public IActionResult OnPost()
        {
            ModelState.Remove(nameof(Order));
            return Page();
        }
    }
    
    public class Order
    {
        public int? Id { get; set; }
        
        public DateTime? OrderDate { get; set; }
        public OrderDetail[] OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public int? ProductId { get; set; }
        public int? Count { get; set; }
    }
}