namespace EcommerceBusinessLayer
{
    interface IHistory
    {
        void displayAllHistoryByStore(int storeId);
        void displayAllHistoryByCustomer(int customerId);
    }
}
