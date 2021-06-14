
namespace Mapper
{
    public static class MapperClassAppToDb
    {
        public static EcommerceDbContext.Account AppAccountToDbAccount(StoreModels.Account accountObj)
        {
            EcommerceDbContext.Account account = new EcommerceDbContext.Account()
            {
                Username = accountObj.Username,
                Password = accountObj.Password,
            };

            return account;
        }

        public static EcommerceDbContext.Customer AppCustomerToDbCustomer(StoreModels.Customer customerObj)
        {
            EcommerceDbContext.Customer customer = new EcommerceDbContext.Customer()
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

        public static EcommerceDbContext.Store AppStoreToDbStore(StoreModels.Store storeObj)
        {
            EcommerceDbContext.Store store = new EcommerceDbContext.Store()
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

        public static EcommerceDbContext.Product AppProducToDbProduct(StoreModels.Product productObj)
        {
            EcommerceDbContext.Product product = new EcommerceDbContext.Product()
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