using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            Category beverages = new Category(1, "Beverages");
            Category condiments = new Category(2, "Condiments");
            Category confections = new Category(3, "Confections");
            Category Dairy   = new Category(4, "Dairy Products");
            Category grains = new Category(5, "Grains/Cereals");
            Category meat = new Category(6, "Meat/Poultry");
            Category produce = new Category(7, "Procduce");
            Category seafood = new Category(8, "Seafood");

            var list = new List<Category>();
            try
            {
                list.Add(beverages);
                list.Add(condiments);
                list.Add(confections);
                list.Add(grains);
                list.Add(meat);
                list.Add(produce);
                list.Add(seafood);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
    }
}
