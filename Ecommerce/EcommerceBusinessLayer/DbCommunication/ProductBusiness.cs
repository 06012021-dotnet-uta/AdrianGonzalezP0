using DbContext;
using EcommerceDbContext;
using Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbProduct = EcommerceDbContext.Product;
using StoreProduct = StoreModels.Product;

namespace EcommerceBusinessLayer
{   
    class ProductBusiness : IProduct
    {
        private readonly Project0Context _;
        private DbProduct dbProduct;
        private StoreProduct StoreProduct;

        public ProductBusiness()
        {
            _ = DbConextProject.DbContext;
        }
        public bool Create(StoreProduct obj)
        {
            dbProduct = MapperClassAppToDb.AppProducToDbProduct(obj);
            try
            {
                _.Products.Add(dbProduct);
                _.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not add new product {obj.ProductName}\nErro Message: {e.Message}");
                return false;
            }
        }

        public bool Delete(StoreProduct obj)
        {
            dbProduct = MapperClassAppToDb.AppProducToDbProduct(obj);
            try
            {
                _.Products.Remove(dbProduct);
                _.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not remove product {obj.ProductName}\nErro Message: {e.Message}");
                return false;
            }
        }

        public List<StoreProduct> GetAllProduct()
        {
            List<StoreProduct> listOfProducts = new();

            try
            {
                List<DbProduct> products = _.Products.ToList();

                listOfProducts = products.ConvertAll(product => MapperClassDBToApp.DbProducToAppProduct(product));

                return listOfProducts;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve all of stores\nError message {e.Message}");
                return null;
            }
        }

        public List<StoreProduct> GetProductByCategory(int CategoryId)
        {
            List<StoreProduct> listOfProducts = new();

            try
            {
                List<DbProduct> products = _.Products.Where(product => product.TypeId == CategoryId).ToList();

                listOfProducts = products.ConvertAll(product => MapperClassDBToApp.DbProducToAppProduct(product));

                return listOfProducts;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve all of stores with: {CategoryId}\nError message {e.Message}");
                return null;
            }
        }

        public List<StoreProduct> GetProductByName(string productName)
        {
            List<StoreProduct> listOfProducts = new();

            try
            {
                List<DbProduct> products = _.Products.Where(product => product.ProductName == productName).ToList();

                listOfProducts = products.ConvertAll(product => MapperClassDBToApp.DbProducToAppProduct(product));

                return listOfProducts;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve all of stores with: {productName}\nError message {e.Message}");
                return null;
            }
        }

        public StoreProduct Read(string keyValue)
        {
            throw new NotImplementedException();
        }

        public bool Update(StoreProduct obj)
        {
            dbProduct = MapperClassAppToDb.AppProducToDbProduct(obj);
            try
            {
                _.Products.Update(dbProduct);
                _.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not add update product {obj.ProductName}\nErro Message: {e.Message}");
                return false;
            }
        }
    }
}
