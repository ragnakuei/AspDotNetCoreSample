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

        [BindProperty]
        public OrderDto OrderDetail { get; set; }

        public Detail(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void OnGet()
        {
            AssignTitle();
            OrderDetail = _orderService.GetOrder(Id);
        }
        
        public IActionResult OnPost()
        {
            _orderService.UpdateOrder(OrderDetail);
            return RedirectToPage("/Order/Detail", new { Id = Id});
        }

        private void AssignTitle()
        {
            var pageRoute = RouteData.Values["page"];
            if (pageRoute.Equals("/Order/Detail"))
            {
                ViewData["Title"] = "Order Detail";
            }

            if (pageRoute.Equals("/Order/Edit"))
            {
                ViewData["Title"] = "Order Edit";
            }
            
            if (pageRoute.Equals("/Order/Create"))
            {
                ViewData["Title"] = "Order Create";
            }
        }
    }
}