using BusinessObjects;
using BusinessObjects.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        public List<Category> GetCategories()
        {
           
            try
            {
                using var context = new MyStoreContext();
                var category = context.Categories.ToList();
                return category;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }
    }
}
