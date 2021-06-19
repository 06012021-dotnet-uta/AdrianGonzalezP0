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
        private Dictionary<Tuple<int, int, int>, Tuple<int,decimal>> _shoppingCart;  // Hold cutomer Items
        private int _customerId;
        private int _storeId;
        private int _quantity;
        private decimal _overAllTotalAmount;

        public Shopping(int customerId, int storeId)
        {
            this._location = new();
            this._shoppingCart = new();
            this._customerId = customerId;
            this._storeId = storeId;
            this._quantity = 0;
            this._overAllTotalAmount = 0.00m;
        }

        /// <summary>
        /// Adds to the items to the cart
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
         async Task<bool> AddItem(ProductModel product, int quantity)
        {
            decimal total = 0.00m;
            bool didAddItem;
            bool hasInventory = await _location.HasInventory(_storeId, product.ProductId);
            bool checkQuantity = quantity <= await _location.Quantity(_storeId, product.ProductId);

            // Check if quantity
            if (hasInventory && checkQuantity)
            {
                Console.WriteLine("Try again");
                return false;
            }

            // Create key for cart
            Tuple<int, int, int> products = new(_customerId, _storeId, product.ProductId);

            // Calculate total
            total = product.UnitPrice * quantity;

            // Create value for cart
            Tuple<int, decimal> quantity_total = new(quantity, total);

            _shoppingCart.Add(products, quantity_total);

            // Decrament from inventory 
            didAddItem = await _location.DecramentItem(_storeId, product.ProductId, quantity);

            return didAddItem;
        }

        void DisplayCart()
        {

        }

        void DisplayAllItems()
        {

        }

        decimal CheckOut() { return _overAllTotalAmount; }
    }
}
