using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Writtit.Models;

namespace Writtit.Data.Dapper
{
    public class DCategoryRepository:ICategoryRepository
    {
        private readonly string _connection = ConfigurationManager.ConnectionStrings["Writtit"].ConnectionString;

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection cn = new SqlConnection(_connection))
            {
                categories = cn.Query<Category>("SELECT * FROM Categories").ToList();
            }

            return categories;
        }

        public Category GetCategoryByID(int? categoryID)
        {
            throw new NotImplementedException();
        }

        public void AddNewCategory(Category category)
        {
            using (SqlConnection cn = new SqlConnection(_connection))
            {
                cn.Execute("INSERT INTO Categories (Name) " +
                           "VALUES (@name)", new {name = category.Name});
            }
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
