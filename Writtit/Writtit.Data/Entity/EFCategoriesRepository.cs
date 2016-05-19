using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writtit.Models;
using Writtit.UI.Models;

namespace Writtit.Data
{
    public class EFCategoriesRepository:ICategoryRepository
    {
        WrittitUIContext db = new WrittitUIContext();
        public List<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryByID(int? categoryID)
        {
            return db.Categories.Find(categoryID);
        }

        public void AddNewCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }
    }
}
