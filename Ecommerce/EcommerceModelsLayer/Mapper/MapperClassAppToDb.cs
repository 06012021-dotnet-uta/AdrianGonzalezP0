using StoreAccount = StoreModels.Account;
using DbAccount = EcommerceDbContext.Account;

using StoreCustomer = StoreModels.Customer;
using DbCustomer = EcommerceDbContext.Customer;

using StoreStore = StoreModels.Store;
using DbStore = EcommerceDbContext.Store;

using StoreType = StoreModels.Category;
using DbType = EcommerceDbContext.Type;

using StoreProduct = StoreModels.Product;
using DbProduct = EcommerceDbContext.Product;

using StoreOrder = StoreModels.Order;
using DbOrder = EcommerceDbContext.Order;

using StoreInventory = StoreModels.Inventory;
using DbInventory = EcommerceDbContext.Inventory;


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
                Username = customerObj.Username,
                Fname = customerObj.Fname,
                Lname = customerObj.Lname,
                Address = customerObj.Street,
                City = customerObj.City,
                State = customerObj.State,
                ZipCode = customerObj.ZipCode,
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
                ZipCode = storeObj.ZipCode,
                ContactNumber = storeObj.ContactNumber,
                Description = storeObj.Description
            };

            return store;
        }

        public static DbProduct AppProducToDbProduct(StoreProduct productObj)
        {
            DbProduct product = new()
            {
                ProductId = productObj.ProductId,
                TypeId = productObj.CategoryId,
                ProductName = productObj.ProductName,
                UnitPrice = productObj.UnitPrice,
                Description = productObj.Description,

            };

            return product;
        }

        public static DbType AppTypeToDbType (StoreType categoryObj)
        {
            DbType category = new()
            {
                TypeId = categoryObj.CategoryId,
                Type1 = categoryObj.CategoryName
            };

            return category;
        }

        public static DbOrder AppOrderToDbOrder(StoreOrder orderObj)
        {
            DbOrder order = new DbOrder()
            {
                CustomerId = orderObj.CustomerId,
                StoreId = orderObj.StoreId,
                ProductId = orderObj.ProductId,
                UnitPrice = orderObj.UnitPrice,
                TotalAmount = orderObj.TotalAmount,
                OrderDate = orderObj.OrderDate
            };

            return order;
        }
        public static DbInventory AppInventoryToDbInventory(StoreInventory inventoryObj)
        {
            DbInventory inventory = new DbInventory()
            {
                StoreId = inventoryObj.StoreId,
                ProductId = inventoryObj.ProductId,
                Quantity = inventoryObj.Quantity
            };

            return inventory;
        }
    }
}