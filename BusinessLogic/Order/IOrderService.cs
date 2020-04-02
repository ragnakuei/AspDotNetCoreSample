using SharedLibrary.Dto;

namespace BusinessLogic.Order
{
    public interface IOrderService
    {
        OrderListDto GetOrderList(int pageIndex, int pageSize);
        OrderDto GetOrder(int orderId);
        void UpdateOrder(OrderDto orderDto);
        int CreateOrder(OrderDto orderDto);
        void DeleteOrder(int orderId);
    }
}