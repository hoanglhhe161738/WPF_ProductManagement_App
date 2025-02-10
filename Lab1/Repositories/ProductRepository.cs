using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product) => ProductDAO.AddProduct(product);

        public void DeleteProduct(int productId) => ProductDAO.DeleteProduct(productId);

        public Product GetProductById(int productId) => ProductDAO.GetProductById(productId);

        public List<Product> GetProducts() => ProductDAO.GetProducts();

        public void UpdateProduct(Product product) => ProductDAO.UpdateProduct(product);
    }
}
