using BusinessObjects;
using DataAccessLayer;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo = new ProductRepository();  
        public void AddProduct(Product product) => _productRepo.AddProduct(product);

        public void DeleteProduct(int productId) => _productRepo.DeleteProduct(productId);

        public Product GetProductById(int productId) => _productRepo.GetProductById(productId);

        public List<Product> GetProducts() => _productRepo.GetProducts();

        public void UpdateProduct(Product product) => _productRepo.UpdateProduct(product);
    }
}
