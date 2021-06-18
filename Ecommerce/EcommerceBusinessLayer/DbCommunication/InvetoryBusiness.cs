using DbContext;
using EcommerceDbContext;
using Mapper;
using Microsoft.EntityFrameworkCore;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbInventory = EcommerceDbContext.Inventory;
using StoreInventory = StoreModels.Inventory;
using DbStore = EcommerceDbContext.Store;
using DbProduct = EcommerceDbContext.Product;


namespace EcommerceBusinessLayer
{
    public class InvetoryBusiness : IInventory
    {
        private readonly Project0Context _;
        private DbInventory dbInventory;
        private StoreInventory storeInventory;

        public InvetoryBusiness()
        {
            _ = DbConextProject.DbContext;
        }
        public bool Create(StoreInventory obj)
        {
            dbInventory = MapperClassAppToDb.AppInventoryToDbInventory(obj);
            try
            {
                _.Inventories.Add(dbInventory);
                _.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not add Inventory with \n\tStoreId: {obj.StoreId}\n\tProductId {obj.ProductId}\nErro Message: {e.Message}");
                return false;
            }
        }

        public bool Delete(StoreInventory obj)
        {
            dbInventory = MapperClassAppToDb.AppInventoryToDbInventory(obj);
            try
            {
                _.Inventories.Remove(dbInventory);
                _.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not remove Inventory \n\tStoreId: {obj.StoreId}\n\tProductId {obj.ProductId}\nErro Message: {e.Message}");
                return false;
            }
        }

        public List<StoreInventory> GetAllInventory()
        {
            List<StoreInventory> listOfInventory = new();

            try
            {
                List<DbInventory> productsList = _.Inventories.ToList();

                listOfInventory = productsList.ConvertAll(product => MapperClassDBToApp.DbInventoryToAppInventory(product));

                return listOfInventory;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve all of stores\nError message {e.Message}");
                return null;
            }
        }

        public StoreInventory GetInventory(int storeId, int productId)
        {
            try
            {
                dbInventory = _.Inventories
                    .Where(inventory => inventory.StoreId == storeId && inventory.ProductId == productId)
                    .SingleOrDefault();

                storeInventory = MapperClassDBToApp.DbInventoryToAppInventory(dbInventory);
                return storeInventory;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve Inventory:\n\tStoreId: {storeId}\n\tProductId: {productId}\nError message {e.Message}");
                return null;
            }
        }

        public List<StoreInventory> GetInventoryByProductId(int productId)
        {
            List<StoreInventory> storeInventoryList = new();
            try
            {
                List<DbInventory> dbInventoryList= _.Inventories
                    .Where(inventory => inventory.ProductId == productId).ToList();

                storeInventory = MapperClassDBToApp.DbInventoryToAppInventory(dbInventory);
                return storeInventoryList;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve Inventory:\n\tProductId: {productId}\nError message {e.Message}");
                return null;
            }
        }

        public List<StoreInventory> GetInventoryByStoreId(int storeId)
        {
            List<StoreInventory> storeInventoryList = new();
            try
            {
                List<DbInventory> dbInventoryList = _.Inventories
                    .Where(inventory => inventory.StoreId == storeId).ToList();

                storeInventory = MapperClassDBToApp.DbInventoryToAppInventory(dbInventory);
                return storeInventoryList;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve Inventory:\n\tStoreId: {storeId}\nError message {e.Message}");
                return null;
            }
        }

        public bool HasInventory(StoreInventory inventory)
        {
            dbInventory = MapperClassAppToDb.AppInventoryToDbInventory(inventory);

            try
            {
                bool check = _.Inventories.Contains(dbInventory);
                return check;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wront");
                return false;
            }
        }

        public StoreInventory Read(string keyValue)
        {
            throw new NotImplementedException();
        }

        public bool Update(StoreInventory obj)
        {
            dbInventory = MapperClassAppToDb.AppInventoryToDbInventory(obj);
            try
            {
                _.Inventories.Update(dbInventory);
                _.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not remove Inventory \n\tStoreId: {obj.StoreId}\n\tProductId {obj.ProductId}\nErro Message: {e.Message}");
                return false;
            }
        }
    }
}
