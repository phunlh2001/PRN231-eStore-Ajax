using BusinessObjects.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dao
{
    public class CategoryDao
    {
        #region Singleton Intance
        private static CategoryDao instance;
        private static readonly object instanceLock = new object();
        public static CategoryDao GetInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDao();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public Category GetById(int id)
        {
            Category category;
            try
            {
                using var context = new ApplicationDbContext();
                category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            List<Category> categories;
            try
            {
                using var context = new ApplicationDbContext();
                categories = context.Categories.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return categories;
        }
    }
}
