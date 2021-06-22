using System;
using DbContext;
using System.Linq;
using EcommerceDbContext;
using DbStore = EcommerceDbContext.Store;
using StoreModel = StoreModels.Store;
using System.Collections.Generic;
using Mapper;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBusinessLayer
{
    public class StoreBusiness 
    {
        private readonly Project0Context _;
        private DbStore dbStore;
        private StoreModel storeModel;

        public StoreBusiness()
        {
            _ = DbConextProject.DbContext;
        }

        public bool Create(StoreModel obj)
        {
            dbStore = MapperClassAppToDb.AppStoreToDbStore(obj);
            try
            {
                _.Stores.Add(dbStore);
                _.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not add store {obj.StoreName}\nErro Message: {e.Message}");
                return false;
            }
        }

        public bool Delete(StoreModel obj)
        {
            dbStore = MapperClassAppToDb.AppStoreToDbStore(obj);
            try
            {
                _.Stores.Remove(dbStore);
                _.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not delete {obj.StoreName}\nErro Message: {e.Message}");
                return false;
            }
        }

        public List<StoreModel> GetAllStore()
        {
            List<StoreModel> listOfStores = new();

            try
            {
                List<DbStore> stores = _.Stores.ToList();

                listOfStores = stores.ConvertAll(store => MapperClassDBToApp.DbStoreToAppStore(store));

                return listOfStores;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve all of stores\nError message {e.Message}");
                return null;
            }
        }

        public StoreModel GetStoreById(int storeId)
        {
            throw new NotImplementedException();
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

        public List<StoreModel> GetStoreByName(string Name)
        {
            List<StoreModel> listOfStores = new();

            try
            {
                List<DbStore> stores = _.Stores.Where(store => store.StoreName == Name).ToList();

                listOfStores = stores.ConvertAll(store => MapperClassDBToApp.DbStoreToAppStore(store));

                return listOfStores;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve all of stores\nError message {e.Message}");
                return null;
            }
        }

        public StoreModel Read(string keyValue)
        {
            throw new NotImplementedException();
        }

        public bool Update(StoreModel obj)
        {
            dbStore = MapperClassAppToDb.AppStoreToDbStore(obj);
            try
            {
                _.Stores.Update(dbStore);
                _.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not update {obj.StoreName}\nErro Message: {e.Message}");
                return false;
            }
        }
    }
}
