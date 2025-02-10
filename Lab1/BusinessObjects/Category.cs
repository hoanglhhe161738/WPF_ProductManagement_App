using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Category
    {
        private ICollection<Product> products;

        public Category() {
            Products = new HashSet<Product>();
        }
        public Category(int id, string categoryName) 
        { 
            this.CategoryId = id;
            this.CategoryName = categoryName;
        }
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; } = string.Empty;

        public virtual ICollection<Product> Products { get; set; }
    }
}
