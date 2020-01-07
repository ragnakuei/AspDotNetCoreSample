﻿using SharedLibrary.Dto;

namespace BusinessLogic.Order
{
    public interface IOrderService
    {
        OrderListDto GetOrderList(int index, int pageIndex);
        OrderDto GetOrder(int orderId);
        void UpdateOrder(OrderDto orderDto);
        int CreateOrder(OrderDto orderDto);
        void DeleteOrder(int orderId);
    }
}