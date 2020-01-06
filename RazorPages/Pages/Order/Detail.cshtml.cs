using BusinessLogic.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Dto;

namespace RazorPages.Pages.Order
{
    public class Detail : PageModel
    {
        private readonly IOrderService _orderService;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Detail(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        public OrderDto OrderDetail { get; private set; }
        
        public void OnGet()
        {
            OrderDetail = _orderService.GetOrder(Id);
        }
    }
}