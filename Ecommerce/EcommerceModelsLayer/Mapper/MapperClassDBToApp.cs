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
    public static class MapperClassDBToApp
    {
        public static StoreAccount DbAccountToClassAccount(DbAccount accountObj)
        {
            StoreAccount account = new()
            {
                Username = accountObj.Username,
                Password = accountObj.Password,
            };

            return account;
        }

        public static StoreCustomer DbCustomerToClassCustomer(DbCustomer customerObj)
        {
            StoreCustomer customer = new()
            {
                CustomerId = customerObj.CustomerId,
                Username = customerObj.Username,
                Fname = customerObj.Fname,
                Lname = customerObj.Lname,
                Street = customerObj.Address,
                City = customerObj.City,
                State = customerObj.State,
                ZipCode = customerObj.ZipCode,
                ContactNumber = customerObj.ContactNumber,
                Email = customerObj.Email
            };

            return customer;
        }

        public static StoreStore DbStoreToAppStore(DbStore storeObj)
        {
            StoreStore store = new()
            {
                StoreId = storeObj.StoreId,
                StoreName = storeObj.StoreName,
                Street = storeObj.Address,
                City = storeObj.State,
                ZipCode = storeObj.ZipCode,
                ContactNumber = storeObj.ContactNumber,
                Description = storeObj.Description
            };

            return store;
        }

        public static StoreProduct DbProducToAppProduct(DbProduct productObj)
        {
            StoreProduct product = new()
            {
                ProductId = productObj.ProductId,
                CategoryId = (int)productObj.TypeId,
                CategoryName = productObj.ProductName,
                ProductName = productObj.ProductName,
                UnitPrice = (decimal)productObj.UnitPrice,
                Description = productObj.Description,

            };

            return product;
        }

        public static StoreType DbTypeToAppType(DbType categoryObj)
        {
            StoreType category = new()
            {
                CategoryId = categoryObj.TypeId,
                CategoryName = categoryObj.Type1
            };

            return category;
        }

        public static StoreOrder DbOrderToAppOrder(DbOrder orderObj)
        {
            StoreOrder order = new()
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

        public static StoreInventory DbInventoryToAppInventory(DbInventory inventoryObj)
        {
            StoreInventory inventory = new StoreInventory()
            {
                StoreId = inventoryObj.StoreId,
                ProductId = inventoryObj.ProductId,
                Quantity = (int)inventoryObj.Quantity
            };

            return inventory;
        }
    }
}
