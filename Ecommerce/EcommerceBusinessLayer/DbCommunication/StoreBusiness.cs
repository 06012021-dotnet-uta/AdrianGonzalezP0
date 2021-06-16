using System;
using DbContext;
using System.Linq;
using EcommerceDbContext;
using DbStore = EcommerceDbContext.Store;
using System.Collections.Generic;

namespace EcommerceBusinessLayer
{
    public class StoreBusiness: IStoreBusiness
    {
        private readonly Project0Context _;

        public StoreBusiness()
        {
            _ = DbConextProject.DbContext;
        }

        public void DisplayAllStores()
        {
            int num = 1;
            try
            {
                var stores = _.Stores.OrderBy(store => store.StoreName);

                foreach(var store in stores)
                {
                    Console.WriteLine($"{num++}. {store.StoreName}");
                } 
            }
            catch (ArgumentNullException e)
            {

                throw new Exception($"Could not retrieve store from database: {e.Message}");
            }
        }

        public long LengthOfStore()
        {
            try
            {
                long length = _.Stores.LongCount();
                return length;

            }
            catch (ArgumentNullException e)
            {

                throw new Exception($"Could not retrieve store from database: {e.Message}");

            } 
        }

        public List<DbStore> SearchByStoreName(string storeName)
        {
            try
            {
                List<DbStore> stores = _.Stores.Where(st => st.StoreName == storeName).ToList();
                return stores;

            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve store from database: {e.Message}");
                return null;

            }
        }

        public List<DbStore> RetrieveAllStores()
        {
            try
            {
                var stores = _.Stores.OrderBy(store => store.StoreName).ToList();
                return stores;


            }
            catch (ArgumentNullException e)
            {

                throw new Exception($"Could not retrieve store from database: {e.Message}");
            }
        }
    }
}
