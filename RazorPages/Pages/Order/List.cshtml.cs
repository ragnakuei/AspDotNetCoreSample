using System;
using System.Threading.Tasks;
using BusinessLogic.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Dto;

namespace RazorPages.Pages.Order
{
    public class List : PageModel
    {
        private readonly IOrderService _orderService;

        public List(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [BindProperty]
        public OrderDto Order { get; set; }
        
        
        public IActionResult OnGet()
        {
            
            return Page();
        }
    }
}