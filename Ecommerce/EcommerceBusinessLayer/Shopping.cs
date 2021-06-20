using EcommerceDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductModel = StoreModels.Product;
using InventoryModel = StoreModels.Inventory;
using Mapper;

namespace EcommerceBusinessLayer
{
    /// <summary>
    /// This class is reponsible for Keeping track of what items are being added onto
    /// </summary>
    public class Shopping
    {
        private readonly Project0Context _;
        private Dictionary<int, int> _shoppingCart;  // Holds customer items
        private int _customerId;                              // Current userId
        private int _storeId;                                 // Current storeId
        private List<InventoryModel> _inventory;              // Keeps Track of the inventory from the store
        public Shopping(int customerId, int storeId, List<InventoryModel> inventory)
        {
            this._shoppingCart = new();
            this._customerId = customerId;
            this._storeId = storeId;
            this._inventory = inventory;
            _ = new(); 
        }

        /// <summary>
        /// Adds to the items to the cart
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
         public bool AddItem(ProductModel product, int quantity)
        {
            bool hasInventory = _inventory.Contains(new InventoryModel() {StoreId = _storeId, ProductId = product.ProductId });
            bool checkQuantity = quantity <= _inventory.Single(inventory => inventory.ProductId == product.ProductId && inventory.StoreId == _storeId).Quantity;

            // Check if quantity
            if (!hasInventory && !checkQuantity)
            {
                Console.WriteLine($"\nError - CheckQuantity: {checkQuantity} CheckInventory: {hasInventory}\n");
                return false;
            }

            // Checks to see if item exists if fails it add new item to cart
            if (_shoppingCart.ContainsKey(product.ProductId))
            {
                _shoppingCart[product.ProductId] += quantity;
                Console.WriteLine($"Total in cart {_shoppingCart.Count}");

            } else
            {
                _shoppingCart.Add(product.ProductId, quantity);
                Console.WriteLine($"Total in cart {_shoppingCart.Count}");
            }

            //Decrament items
            var changeInventory = _inventory.SingleOrDefault(inventory => inventory.ProductId == product.ProductId && inventory.StoreId == _storeId);
            changeInventory.Quantity -= quantity;

            return true;
        }

        /// <summary>
        /// Returns all current items from cart
        /// </summary>
        /// <returns>List of Products with its quantity</returns>
        public Dictionary<int, int> GetCart() => _shoppingCart;
        
        /// <summary>
        /// Checks out with all items that are in the cart.
        /// </summary>
        /// <returns> A reciete </returns>
        public string CheckOut(List<ProductModel> products) 
        {
            decimal total = 0.00m;

            // Convert inventory to dbInventory type
            var inventory = _inventory.ConvertAll(invent => MapperClassAppToDb.AppInventoryToDbInventory(invent));


            _.Inventories.UpdateRange(inventory);


            //Add items to order
            foreach (var product in _shoppingCart)
            {
                ProductModel addProduct = products.Find(pro => pro.ProductId == product.Key);
                
                
                total += (addProduct.UnitPrice * product.Value);
                Order orders = new()
                {
                    CustomerId = _customerId,
                    StoreId = _storeId,
                    ProductId = addProduct.ProductId,
                    UnitPrice = addProduct.UnitPrice,
                    Quantity = product.Value,
                    TotalAmount = (addProduct.UnitPrice * product.Value)
                };

                try
                {
                    _.Orders.Add(orders);
                    _.Inventories.UpdateRange(inventory);
                }
                catch (Exception)
                {
                Console.WriteLine($"Error - Could not add items to order:\n\t{product.Key}");
                continue;
                }
        
            }

            _.SaveChanges();

            return $"Total Amount: {total}";
        }

        /// <summary>
        /// Return a list of all items that based on stores inventory;
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GrabAllProducts()
        {
            List<ProductModel> products = new();
           
            try
            {
                foreach (var inventory in _inventory)
                {
                    Product dbProduct = _.Products.SingleOrDefault(product => product.ProductId == inventory.ProductId);

                    products.Add(MapperClassDBToApp.DbProducToAppProduct(dbProduct));
                }

                return products;
            }
            catch (Exception)
            {
                Console.WriteLine("Error - Could not retrieve all of items");
                return null; 
            }
        }

    }
}
