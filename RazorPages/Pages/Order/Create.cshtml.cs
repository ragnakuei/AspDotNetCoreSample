using BusinessLogic.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Dto;

namespace RazorPages.Pages.Order
{
    public class Create : PageModel
    {
        private readonly IOrderService _orderService;

        [BindProperty]
        public OrderDto OrderDetail { get; set; }

        public Create(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Order Create";
            OrderDetail = new OrderDto
                          {
                              Details = new []
                                        {
                                            new OrderDetailDto(), 
                                            new OrderDetailDto(), 
                                        }
                          };
        }
        
        public IActionResult OnPost()
        {
            var orderId = _orderService.CreateOrder(OrderDetail);
            return RedirectToPage("/Order/Detail", new { Id = orderId});
        }
    }
}