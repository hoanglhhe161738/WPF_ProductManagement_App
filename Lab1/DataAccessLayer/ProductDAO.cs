using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private static List<Product> products = new List<Product>()
        {
            new Product(1, "Chai", 3, 12, 18),
            new Product(2, "Chang", 1, 23, 19),
            new Product(3, "Aniseed Syrup", 2, 23, 10)
        };
        //public static List<Product> InitialProduct() {
        //    Product chai = new Product(1, "Chai", 3, 12, 18);
        //    Product chang = new Product(2, "Chang", 1, 23, 19);
        //    Product aniseed = ;
        //    List<Product> productList = new List<Product>();
        //    productList.Add(chai);
        //    productList.Add(chang);
        //    productList.Add(aniseed);
        //    return productList;
        //}
        private static int getKey() => products.Count() + 1;
        public static List<Product> GetProducts() => products;
        public static void AddProduct(Product product)
        {
            product.ProductId = getKey();
            products.Add(product);
        } 

        public static void UpdateProduct(Product product)
        {
            Product productUpdate = products.Find(p => p.ProductId == product.ProductId);
            if (productUpdate != null)
            {
                productUpdate.ProductId = product.ProductId;
                productUpdate.ProductName = product.ProductName;
                productUpdate.UnitPrice = product.UnitPrice;
                productUpdate.UnitsInstock = product.UnitsInstock;
                productUpdate.CategpryId = product.CategpryId;
            }
            
        }

        public static void DeleteProduct(int id)
        {
            var productDelete = products.Find(p => p.ProductId == id);
            if(productDelete != null)
                products.Remove(productDelete);
        }
        public static Product GetProductById(int id) => products.Find(p => p.ProductId == id);

    }
}
