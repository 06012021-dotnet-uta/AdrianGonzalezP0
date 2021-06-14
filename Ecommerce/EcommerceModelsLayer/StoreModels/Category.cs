namespace StoreModels
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Category(int CategoryId, string CategoryName)
        {
            this.CategoryId = CategoryId;
            this.CategoryName = CategoryName;
        }

        public Category(Category categoryObj)
        {
            this.CategoryId = categoryObj.CategoryId;
            this.CategoryName = categoryObj.CategoryName;
        }
    }
}