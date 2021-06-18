using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBusinessLayer
{
    public class ShoppingCart
    {
        Dictionary<Tuple<int, int, int>, int> orderList; // Hold custmerId,StoreId,ProductId along with quantity
        int customerId;
        int storeId;
        decimal totalAmount;

        public ShoppingCart(int customerId, int storeId, int location)
        {
            this.customerId = customerId;
            this.storeId = storeId;
            orderList = new();
            totalAmount = 0.00m;
        }

        void AddItem(int productId, int quantity)
        {
           // Check if Quantity
           if(quantity <= 0)
            {
                Console.WriteLine("Cannot be less than zero items");
            }

            var keyValue = new Tuple<int, int, int>(customerId,storeId,productId);
            orderList.Add(keyValue, quantity);
        }
    }
}
