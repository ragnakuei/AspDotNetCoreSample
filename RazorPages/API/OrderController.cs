using BusinessLogic.Order;
using Microsoft.AspNetCore.Mvc;

namespace RazorPages.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost, Route("list")]
        public IActionResult List(PageInfo pageInfo)
        {
            var result = _orderService.GetOrderList(pageInfo.Current - 1, pageInfo.RowCount);
            return Ok(new
                      {
                          current = pageInfo.Current,
                          rowCount = pageInfo.RowCount,
                          total = result.TotalCount,
                          rows = result.Items,
                      });
        }
    }

    public class PageInfo
    {
        public int Current { get; set; } = 1;
        public int RowCount { get; set; } = 10;
    }
}