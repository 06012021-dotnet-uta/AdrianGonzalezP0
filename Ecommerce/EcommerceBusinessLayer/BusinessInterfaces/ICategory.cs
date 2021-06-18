using StoreModels;
using System.Collections.Generic;

namespace EcommerceBusinessLayer
{
    interface ICategory: ICrud<Category>
    {
        List<Category> GetAllCategories();
        List<Category> GetCategoryByName(string categoryName);
        Category GetCategoryById(int categoryId);
    }
}
