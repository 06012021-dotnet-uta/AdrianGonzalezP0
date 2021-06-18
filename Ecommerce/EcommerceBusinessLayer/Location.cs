using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBusinessLayer
{
    public class Location
    {
        InvetoryBusiness invetory = new();
        public bool HasInventory(int storeId, int productId)
        {
            StoreModels.Inventory checkInventory = new() {
                StoreId = storeId,
                ProductId = productId
            };
            return invetory.HasInventory(checkInventory);
        }
    }
}
