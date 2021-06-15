using System;
using DbContext;
using System.Linq;
using EcommerceDbContext;

namespace EcommerceBusinessLayer
{
    public class OrderHistory : IHistory
    {
        private Project0Context _context;

        public OrderHistory()
        {
            _context = DbConextProject.DbContext;
        }

        public void displayAllHistoryByCustomer(int customerId)
        {
            try
            {
                var orders = _context.Orders.Where(order => order.CustomerId == customerId).ToList();
                Console.WriteLine($"\t\tOrder History\n");

                foreach (var order in orders)
                {
                    Console.WriteLine($"Customer: {order.CustomerId}\nStore: {order.StoreId}\nProduct: {order.ProductId}\nUnitPrice: {order.UnitPrice}\nTotal Amount: {order.TotalAmount}\nOrder Date: {order.OrderDate}\n");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void displayAllHistoryByStore(int store)
        {
            try
            {
                var orders = _context.Orders.Where(order => order.StoreId == store).ToList();
                Console.WriteLine($"\t\tOrder History\n");

                foreach (var order in orders)
                {
                    Console.WriteLine($"Customer: {order.CustomerId}\nStore: {order.StoreId}\nProduct: {order.ProductId}\nUnitPrice: {order.UnitPrice}\nTotal Amount: {order.TotalAmount}\nOrder Date: {order.OrderDate}\n");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
