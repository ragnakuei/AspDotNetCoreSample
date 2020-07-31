using BusinessLogic.Order;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dto;

namespace Angular.Controllers
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

        [HttpGet, Route("list")]
        public IActionResult List(int pageIndex = 0, int pageSize = 10)
        {
            var result = _orderService.GetOrderList(pageIndex, pageSize);
            return Ok(result);
        }

        [HttpGet, Route("detail/{orderId:int}")]
        public IActionResult Order(int orderId)
        {
            var result = _orderService.GetOrder(orderId);
            return Ok(result);
        }

        [HttpPost, Route("create")]
        public IActionResult CreateOrder(OrderDto orderDto)
        {
            var newOrderId = _orderService.CreateOrder(orderDto);
            return Ok(newOrderId);
        }

        [HttpPut, Route("{orderId:int}")]
        public IActionResult UpdateOrder(int orderId, OrderDto orderDto)
        {
            _orderService.UpdateOrder(orderDto);
            return Ok(orderId);
        }

        [HttpDelete, Route("{orderId:int}")]
        public IActionResult DeleteOrder(int orderId)
        {
            _orderService.DeleteOrder(orderId);
            return Ok();
        }
    }
}
