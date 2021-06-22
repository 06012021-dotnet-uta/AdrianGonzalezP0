using StoreModels;
using System.Collections.Generic;

namespace EcommerceBusinessLayer
{
    interface IOrder: ICrud<Order>
    {
        List<Order> GetOrderByStoreId(int orderId);
        List<Order> GetOrderByCustomerId(int storeId);
        List<Order> GetAllOrders();
    }
}
