using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writtit.Models;

namespace Writtit.Data
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();

        Category GetCategoryByID(int? categoryID);

        void AddNewCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(Category category);
    }
}
