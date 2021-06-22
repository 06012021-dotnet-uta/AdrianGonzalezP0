using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceDbContext;
using InventoryModels = StoreModels.Inventory;
using DbInventory = EcommerceDbContext.Inventory;
using Mapper;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBusinessLayer
{
    public class Location
    {
        private readonly Project0Context _;
        public Location ()
        {
            _ = new();
        }

        /// <summary>
        /// We need to check if invtory exist before making a purchase
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool HasInventory(int storeId, int productId)
        {
            DbInventory currrentInventory = new()
            {
                StoreId = storeId,
                ProductId = productId,
            };

            try
            {
                bool check = _.Inventories.Contains(currrentInventory);
                return check;
            }
            catch (Exception)
            {
                Console.WriteLine("Error - Something went wront");
                return false;
            }
        }

        /// <summary>
        /// Decrament's the item from inventory
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="productId"></param>
        /// <returns>Returns true if successfully decramented from Inventory</returns>
        public bool DecramentItem(int storeId, int productId, int quantity)
        {
            DbInventory currrentInventory = new()
            {
                StoreId = storeId,
                ProductId = productId,
                Quantity = quantity
            };

            try
            {
                return true;
            }
            catch (DbUpdateException)
            {
                Console.WriteLine($"\nError - Could not remove Inventory \n\tStoreId: {storeId}\n\tProductId {productId}\n");
                return false;
            }
        }

        //public List<ProductModel> GetAllProduct(int storeId)
        //{
        //    List<ProductModel> listOfProducts = new();

        //    try
        //    {
        //        List<DbInventory> inventories = _.Inventories.Where(inventory => inventory.StoreId == storeId).ToList();

        //        foreach (var inventory in inventories)
        //        {
        //            DbProduct dbProduct = _.Products.Single(product => product.ProductId == inventory.ProductId);

        //            listOfProducts.Add(MapperClassDBToApp.DbProducToAppProduct(dbProduct));
        //        }

        //        return listOfProducts;
        //    }
        //    catch (ArgumentNullException e)
        //    {

        //        Console.WriteLine($"Could not retrieve all of stores with: {storeId}\nError message {e.Message}");
        //        return null;
        //    }
        //}

        public int GetQuantity(int storeId, int productId)
        {
            try
            {
                int quantity = (int)_.Inventories.Single(inventory => inventory.StoreId == storeId && inventory.ProductId == productId).Quantity;
                return quantity;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"\nError - Could not Grab item and its quantity. storeId: {storeId} productId {productId}\n");
                return 0;
            }
        }
    }
}
