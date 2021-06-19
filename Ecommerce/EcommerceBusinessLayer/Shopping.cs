using EcommerceDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductModel = StoreModels.Product;

namespace EcommerceBusinessLayer
{
    /// <summary>
    /// This class is reponsible for Keeping track of what items are being added onto
    /// </summary>
    public class Shopping
    {
        private readonly Location _location;
        private readonly Project0Context _;
        private Dictionary<ProductModel, int> _shoppingCart;  // Holds customer items
        private int _customerId;                              // Current userId
        private int _storeId;                                 // Current storeId 

        public Shopping(int customerId, int storeId)
        {
            this._location = new();
            this._shoppingCart = new();
            this._customerId = customerId;
            this._storeId = storeId;
            _ = new(); 
        }

        /// <summary>
        /// Adds to the items to the cart
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
         async Task<bool> AddItem(ProductModel product, int quantity)
        {
            bool hasInventory = await _location.HasInventory(_storeId, product.ProductId);
            bool checkQuantity = quantity <= await _location.Quantity(_storeId, product.ProductId);

            // Check if quantity
            if (hasInventory && checkQuantity)
            {
                Console.WriteLine("Try again");
                return false;
            }

            // Add item to cart
            _shoppingCart.Add(product, quantity);

            return true;
        }

        /// <summary>
        /// Returns all current items from cart
        /// </summary>
        /// <returns>List of Products with its quantity</returns>
        Dictionary<ProductModel, int> GetCart() => _shoppingCart;
        
        /// <summary>
        /// Checks out with all items that are in the cart.
        /// </summary>
        /// <returns> A reciete </returns>
        public async Task<string> CheckOut() 
        {
            decimal total = 0.00m;
            //Add items to order
            foreach (var product in _shoppingCart)
            {
                total += (product.Key.UnitPrice * product.Value);
                Order orders = new()
                {
                    CustomerId = _customerId,
                    StoreId = _storeId,
                    ProductId = product.Key.ProductId,
                    Quantity = product.Value,
                    TotalAmount = (product.Key.UnitPrice * product.Value)
                };

                try
                {
                    await _.Orders.AddAsync(orders);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Could not add items to order:\n\t{product.Key.productInfo()}");
                    continue;
                }
            }

            return $"Total Amount: {total}";
        }
    }
}
