using System;

namespace StoreModels
{
    public class Order
    {
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public Order() { }
        public Order(int CusotmerId, int StoreId, int ProductId, decimal UnitPrice, int Quantity, decimal TotalAmount, DateTime OrderDate)
        {
            this.CustomerId = CusotmerId;
            this.StoreId = StoreId;
            this.ProductId = ProductId;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
            this.TotalAmount = TotalAmount;
            this.OrderDate = OrderDate;
        }
    }
}