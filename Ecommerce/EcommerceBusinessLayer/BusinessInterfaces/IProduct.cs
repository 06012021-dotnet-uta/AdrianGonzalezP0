using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBusinessLayer
{
    interface IProduct: ICrud<Product>
    {
        List<Product> GetAllProduct();
        List<Product> GetProductByName(string productName);
        List<Product> GetProductByCategory(int CategoryId);

    }
}
