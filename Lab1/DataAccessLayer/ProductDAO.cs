using BusinessObjects.Models;


namespace DataAccessLayer
{
    public class ProductDAO
    {
        private static List<Product> products = new List<Product>()
        {
            //new Product(1, "Chai", 3, 12, 18),
            //new Product(2, "Chang", 1, 23, 19),
            //new Product(3, "Aniseed Syrup", 2, 23, 10)
        };
        private static int key = getKey();
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
        private static int getKey() => products.Count();
        public List<Product> GetProducts()
        {
            try
            {
                using var context = new MyStoreContext();
                var proucts = context.Products.ToList();
                return proucts;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }
        public  void AddProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        } 

        public void UpdateProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                using var context = new MyStoreContext();
                var product = context.Products.SingleOrDefault(p => p.ProductId == id);   
                context.Products.Remove(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public  Product GetProductById(int id)
        {
            try
            {
                using var context = new MyStoreContext();
                var product = context.Products.Find(id);
                return product;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }

    }
}
