using System.Collections.Generic;
using StoreModels;

namespace EcommerceBusinessLayer
{
    interface IStore: ICrud<Store>
    {
        Store GetStoreById(int storeId);
        List<Store> GetStoreByName(string Name);
        List<Store> GetStoreByLocation(string Street);
        List<Store> GetAllStore();

    }
}
