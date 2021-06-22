using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModels;

namespace EcommerceBusinessLayer
{
    interface IInventory: ICrud<Inventory>
    {
        List<Inventory> GetAllInventory();
        List<Inventory> GetInventoryByStoreId(int storeId);
        List<Inventory> GetInventoryByProductId(int product);
        Inventory GetInventory(int store, int product);
    }
}
