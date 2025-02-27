using BusinessObjects;
using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAO categoryDAO = new CategoryDAO();
        public List<Category> GetCategories() => categoryDAO.GetCategories();
    }
}
