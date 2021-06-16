using System;
using DbContext;
using System.Linq;
using EcommerceDbContext;
using Mapper;
using StoreOrder = StoreModels.Order;
using DbOrder = EcommerceDbContext.Order;

namespace EcommerceBusinessLayer
{
    public class OrderBusiness : IOrder
    {
        private readonly Project0Context _context;

        public OrderBusiness()
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

        public bool placeOrder(StoreOrder orderObj)
        {
            DbOrder newOrder = MapperClassAppToDb.AppOrderToDbOrder(orderObj);

            try
            {
                var orderPlace = _context.Orders.Add(newOrder);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nCould not save changes\n Error Message: {e.Message}\n");
                return false;
            }   
        }
    }
}
