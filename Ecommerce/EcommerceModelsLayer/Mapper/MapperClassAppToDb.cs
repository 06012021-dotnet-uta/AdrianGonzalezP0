
using System;
using StoreAccount = StoreModels.Account;
using DbAccount = EcommerceDbContext.Account;

using StoreCustomer = StoreModels.Customer;
using DbCustomer = EcommerceDbContext.Customer;

using StoreStore = StoreModels.Store;
using DbStore = EcommerceDbContext.Store;

using StoreProduct = StoreModels.Product;
using DbProduct = EcommerceDbContext.Product;

namespace Mapper
{
    public static class MapperClassAppToDb
    {
        public static DbAccount AppAccountToDbAccount(StoreAccount accountObj)
        {
            DbAccount account = new()
            {
                Username = accountObj.Username,
                Password = accountObj.Password,
            };

            return account;
        }

        public static DbCustomer AppCustomerToDbCustomer(StoreCustomer customerObj)
        {
            DbCustomer customer = new()
            {
                CustomerId = customerObj.CustomerId,
                Username = customerObj.Account.Username,
                Fname = customerObj.Fname,
                Lname = customerObj.Lname,
                Address = customerObj.Street,
                City = customerObj.City,
                State = customerObj.State,
                ZipCode = customerObj.Zipcode,
                ContactNumber = customerObj.ContactNumber,
                Email = customerObj.Email
            };

            return customer;
        }

        public static DbStore AppStoreToDbStore(StoreStore storeObj)
        {
            DbStore store = new()
            {
                StoreId = storeObj.StoreId,
                StoreName = storeObj.StoreName,
                Address = storeObj.Street,
                City = storeObj.State,
                ZipCode = storeObj.Zipcode,
                ContactNumber = storeObj.ContactNumber,
                Description = storeObj.Description
            };

            return store;
        }

        public static DbProduct AppProducToDbProduct(StoreProduct productObj)
        {
            DbProduct product = new()
            {
                ProductId = productObj.CategoryId,
                TypeId = productObj.CategoryId,
                ProductName = productObj.ProductName,
                UnitPrice = productObj.UnitPrice,
                Description = productObj.Description,

            };

            return product;
        }

        // public static EcommerceDbContext.Type AppTypeToDbType(StoreModels.Category categoryObj)
        // {

        // }
    }
}