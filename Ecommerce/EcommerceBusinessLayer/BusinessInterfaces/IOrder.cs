using StoreOrder = StoreModels.Order;

namespace EcommerceBusinessLayer
{
    interface IOrder
    {
        void displayAllHistoryByStore(int storeId);
        void displayAllHistoryByCustomer(int customerId);
        bool placeOrder(StoreOrder orderObj);
    }
}
