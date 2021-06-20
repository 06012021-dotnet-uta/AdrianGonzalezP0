﻿using EcommerceDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModel = StoreModels.Store;
using DbStore = EcommerceDbContext.Store;
using ProductModel = StoreModels.Product;
using DbProduct = EcommerceDbContext.Product;
using DbInventory = EcommerceDbContext.Inventory;
using InventoryModel = StoreModels.Inventory;
using Mapper;

namespace EcommerceBusinessLayer
{
    public class Store
    {
        private readonly Project0Context _;

        public Store () 
        {
            _ = new();
        }

        public List<StoreModel> GetAllStore()
        {
            List<StoreModel> listOfStores = new();

            try
            {
                List<DbStore> stores = _.Stores.ToList();

                listOfStores = stores.ConvertAll(store => MapperClassDBToApp.DbStoreToAppStore(store));

                listOfStores.Sort();

                return listOfStores;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve all of stores\nError message {e.Message}");
                return null;
            }
        }

        public List<StoreModel> GetStoreByLocation(string Street)
        {
            List<StoreModel> listOfStores = new();

            try
            {
                List<DbStore> stores = _.Stores.Where(store => store.Address == Street).ToList();

                listOfStores = stores.ConvertAll(store => MapperClassDBToApp.DbStoreToAppStore(store));

                return listOfStores;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve stores named {Street}\nError message {e.Message}");
                return null;
            }
        }

        public List<InventoryModel> GrabAllInventory(int storeId)
        {
            List<InventoryModel> inventory;

            try
            {
                List<DbInventory> inventories = _.Inventories.Where(inventory => inventory.StoreId == storeId).ToList();

                inventory = inventories.ConvertAll(inv => MapperClassDBToApp.DbInventoryToAppInventory(inv));

                return inventory;
                
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve all of stores with: {storeId}\nError message {e.Message}");
                return null;
            }
        }
    }
}
