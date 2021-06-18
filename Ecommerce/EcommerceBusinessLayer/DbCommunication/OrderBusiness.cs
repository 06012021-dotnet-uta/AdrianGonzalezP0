using System;
using DbContext;
using System.Linq;
using EcommerceDbContext;
using Mapper;
using StoreOrder = StoreModels.Order;
using DbOrder = EcommerceDbContext.Order;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBusinessLayer
{
    public class OrderBusiness : IOrder
    {
        private readonly Project0Context _context;

        private DbOrder dbOrder;

        public OrderBusiness()
        {
            _context = DbConextProject.DbContext;
        }

        public bool Create(StoreOrder obj)
        {
            dbOrder = MapperClassAppToDb.AppOrderToDbOrder(obj);
            try
            {
                _context.Orders.Add(dbOrder);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not place order {obj.ProductId}\nErro Message: {e.Message}");
                return false;
            }
        }

        public bool Delete(StoreOrder obj)
        {
            dbOrder = MapperClassAppToDb.AppOrderToDbOrder(obj);
            try
            {
                _context.Orders.Remove(dbOrder);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not remove order {obj.ProductId}\nErro Message: {e.Message}");
                return false;
            }
        }

        public List<StoreOrder> GetAllOrders()
        {
            List<StoreOrder> listOfOrders = new();

            try
            {
                List<DbOrder> orders = _context.Orders.ToList();

                listOfOrders = orders.ConvertAll(orders => MapperClassDBToApp.DbOrderToAppOrder(orders));

                return listOfOrders;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve all of orders\nError message {e.Message}");
                return null;
            }
        }

        public List<StoreOrder> GetOrderByCustomerId(int storeId)
        {
            List<StoreOrder> listOfOrders = new();

            try
            {
                List<DbOrder> orders = _context.Orders.Where(order => order.StoreId == storeId).ToList();

                listOfOrders = orders.ConvertAll(orders => MapperClassDBToApp.DbOrderToAppOrder(orders));

                return listOfOrders;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Could not retrieve order with {storeId}\nError message {e.Message}");
                return null;
            }
        }

        public List<StoreOrder> GetOrderByStoreId(int customerId)
        {
            List<StoreOrder> listOfOrders = new();

            try
            {
                List<DbOrder> orders = _context.Orders.Where(order => order.CustomerId == customerId).ToList();

                listOfOrders = orders.ConvertAll(orders => MapperClassDBToApp.DbOrderToAppOrder(orders));

                return listOfOrders;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Could not retrieve order with {customerId}\nError message {e.Message}");
                return null;
            }
        }

        public StoreOrder Read(string keyValue)
        {
            return null;
        }

        public bool Update(StoreOrder obj)
        {
            dbOrder = MapperClassAppToDb.AppOrderToDbOrder(obj);
            try
            {
                _context.Orders.Update(dbOrder);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not update order {obj.ProductId}\nErro Message: {e.Message}");
                return false;
            }
        }
    }
}
