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
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO productDAO = new ProductDAO();
        public void AddProduct(Product product) => productDAO.AddProduct(product);

        public void DeleteProduct(int productId) => productDAO.DeleteProduct(productId);

        public Product GetProductById(int productId) => productDAO.GetProductById(productId);

        public List<Product> GetProducts() => productDAO.GetProducts();

        public void UpdateProduct(Product product) => productDAO.UpdateProduct(product);
    }
}
