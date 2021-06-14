namespace StoreModels
{
    public class Product : Category
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }

        public Product(string ProductName, decimal UnitPrice, string Description, Category categoryObj) : base(categoryObj)
        {
            this.ProductName = ProductName;
            this.UnitPrice = UnitPrice;
            this.Description = Description;
        }

        public string productInfo()
        {
            string product_info = $"\t\tProduct Information\nProduct name: {this.ProductName}\nCategory: {base.CategoryName}\nUnit Price: {this.UnitPrice}\nDesciption: {this.Description}";
            return product_info;
        }

    }
}