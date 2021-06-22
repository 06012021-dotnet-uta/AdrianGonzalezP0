namespace StoreModels
{
    public class Product : Category
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }

        public Product(): base() { }
        /// <summary>
        /// Responsible of Initializing the prodocuts
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="UnitPrice"></param>
        /// <param name="Description"></param>
        /// <param name="categoryObj"></param>
        public Product(string ProductName, decimal UnitPrice, string Description, Category categoryObj) : base(categoryObj)
        {
            this.ProductName = ProductName;
            this.UnitPrice = UnitPrice;
            this.Description = Description;
        }

        public string productInfo()
        {
            string product_info = $"\t\t{this.ProductName}\n\tProductId: {this.ProductId}\n\tCategory: {base.CategoryName}\n\tUnit Price: {this.UnitPrice}\n\tDesciption: {this.Description}";
            return product_info;
        }

    }
}