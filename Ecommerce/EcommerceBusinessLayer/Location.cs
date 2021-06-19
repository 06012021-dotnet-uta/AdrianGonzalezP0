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
        private DbInventory dbInventory;
        public Location ()
        {
            _ = new();
            dbInventory = new();
        }

        /// <summary>
        /// We need to check if invtory exist before making a purchase
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<bool> HasInventory(int storeId, int productId)
        {
            dbInventory.StoreId = storeId;
            dbInventory.ProductId = productId;

            try
            {
                Task<bool> check = Task.FromResult(_.Inventories.Contains(dbInventory));
                return await check;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wront");
                return false;
            }
        }

        /// <summary>
        /// Decrament's the item from inventory
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="productId"></param>
        /// <returns>Returns true if successfully decramented from Inventory</returns>
        public async Task<bool> DecramentItem(int storeId, int productId, int quantity)
        {

            dbInventory.StoreId = storeId;
            dbInventory.ProductId = productId;
            dbInventory.Quantity = quantity;

            
            try
            {
                _.Inventories.Update(dbInventory);
                await _.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not remove Inventory \n\tStoreId: {storeId}\n\tProductId {productId}\nErro Message: {e.Message}");
                return false;
            }
        }

        public async Task<bool> IncramentItem(int storeId, int productId, int quantity)
        {
            try
            {
                _.Inventories.Update(dbInventory);
                await _.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not remove Inventory \n\tStoreId: {storeId}\n\tProductId {productId}\nErro Message: {e.Message}");
                return false;
            }
        }

        public async Task<int> Quantity(int storeId, int productId)
        {
            try
            {
                dbInventory = await _.Inventories.SingleAsync(inventory => inventory.StoreId == storeId && inventory.ProductId == productId);

                int quantity = (int)dbInventory.Quantity;

                return quantity;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Could not retrive qunatity\nError Message - {e.Message}");
                return -1;
            }
        }
    }
}
