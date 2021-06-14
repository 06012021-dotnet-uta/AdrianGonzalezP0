using System;
using System.Collections.Generic;
namespace StoreModels
{
    public class Inventory
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Inventory(int StoreId, int ProductId, int Quantity)
        {
            this.StoreId = StoreId;
            this.ProductId = ProductId;
            this.Quantity = Quantity;
        }
    }
}