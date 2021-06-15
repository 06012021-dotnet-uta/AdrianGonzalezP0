using System.IO;
namespace StoreModels
{
    public class Order
    {
        public int CusotmerId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderDate { get; set; }

        public Order(int CusotmerId, int StoreId, int ProductId, decimal UnitPrice, int Quantity, decimal TotalAmount, string OrderDate)
        {
            this.CusotmerId = CusotmerId;
            this.StoreId = StoreId;
            this.ProductId = ProductId;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
            this.TotalAmount = TotalAmount;
            this.OrderDate = OrderDate;
        }
    }
}