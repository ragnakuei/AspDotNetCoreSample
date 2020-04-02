using BusinessLogic.Order;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dto;

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
        public IActionResult List(PageInfoDto pageInfoDto)
        {
            var result = _orderService.GetOrderList(pageInfoDto.Current - 1, pageInfoDto.RowCount);
            return Ok(new
                      {
                          current = pageInfoDto.Current,
                          rowCount = pageInfoDto.RowCount,
                          total = result.TotalCount,
                          rows = result.Items,
                      });
        }
    }
}