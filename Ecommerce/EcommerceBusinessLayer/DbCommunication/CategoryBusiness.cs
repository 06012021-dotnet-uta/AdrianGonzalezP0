using System;
using System.Linq;
using EcommerceDbContext;
using Mapper;
using DbContext;
using Microsoft.EntityFrameworkCore;
using StoreCategory = StoreModels.Category;
using DbCategory = EcommerceDbContext.Type;
using System.Collections.Generic;
namespace EcommerceBusinessLayer
{
    class CategoryBusiness : ICategory
    {
        private readonly Project0Context _context;
        private StoreCategory storeCategory;
        private DbCategory dbCategory;
        public CategoryBusiness()
        {
            _context = DbConextProject.DbContext;
        }
        /// <summary>
        /// Creates a new Category
        /// </summary>
        /// <param name="obj">A Category object</param>
        /// <returns>True if successfuly added new Category in Database. False if failed to create new Category</returns>
        public bool Create(StoreCategory obj)
        {
            try
            {
                dbCategory = MapperClassAppToDb.AppTypeToDbType(obj);
                _context.Types.Add(dbCategory);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not create new Category {obj.CategoryName}\nError Message: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Deletes an existing Category
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if Category successfully got deleted. False otherwise</returns>
        public bool Delete(StoreCategory obj)
        {
            try
            {
                dbCategory = MapperClassAppToDb.AppTypeToDbType(obj);
                _context.Types.Remove(dbCategory);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not delete Category {obj.CategoryName}\nError Message: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// A list of all Categories
        /// </summary>
        /// <returns>S list of all categories or null otherwise</returns>
        public List<StoreCategory> GetAllCategories()
        {
            List<StoreCategory> listOfCategory = new();

            try
            {
                List<DbCategory> listDbCategory = _context.Types.ToList();

                listOfCategory = listDbCategory.ConvertAll(category => MapperClassDBToApp.DbTypeToAppType(category));

                return listOfCategory;

            }
            catch (Exception)
            {

                throw;
            }

        }   

        /// <summary>
        /// Returns a single Category with a given Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>A category or null otherwise</returns>
        public StoreCategory GetCategoryById(int categoryId)
        {
            try
            {
                dbCategory = _context.Types.Single(category => category.TypeId == categoryId);
                storeCategory = MapperClassDBToApp.DbTypeToAppType(dbCategory);
                return storeCategory;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"No such category with id {categoryId}\nError Messsage: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// A list of all categories by name
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns>All of cateogries from database</returns>
        public List<StoreCategory> GetCategoryByName(string categoryName)
        {
            List<StoreCategory> listOfCategory = new();

            try
            {
                List<DbCategory> listDbCategory = _context.Types.Where(category => category.Type1 == categoryName).ToList();

                listOfCategory = listDbCategory.ConvertAll(category => MapperClassDBToApp.DbTypeToAppType(category));

                return listOfCategory;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Returns a single Category with a given category name
        /// </summary>
        /// <param name="keyValue">Category Name</param>
        /// <returns>A category or null otherwise</returns>
        public StoreCategory Read(string keyValue)
        {
            try
            {
                dbCategory = _context.Types.Single(category => category.Type1 == keyValue);
                storeCategory = MapperClassDBToApp.DbTypeToAppType(dbCategory);
                return storeCategory;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"No such category with {keyValue}\nError Messsage: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Update existing category with new information
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(StoreCategory obj)
        {
            try
            {
                dbCategory = MapperClassAppToDb.AppTypeToDbType(obj);
                _context.Types.Update(dbCategory);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not update {obj.CategoryName}\nError Message: {e.Message}");
                return false;
            }
        }
    }
}
