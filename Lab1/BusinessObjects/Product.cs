using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Product
    {
        
        public int ProductId {  get; set; }
        public string ProductName {  get; set; }
        public int? CategpryId { get; set; }
        public short? UnitsInstock {  get; set; }
        public decimal? UnitPrice { get; set; }
        public virtual Category Category { get; set; }

        public Product(int productId, string productName, int? categpryId, short? unitsInstock, decimal? unitPrice)
        {
            ProductId = productId;
            ProductName = productName;
            CategpryId = categpryId;
            UnitsInstock = unitsInstock;
            UnitPrice = unitPrice;
        }
        public Product() { }
    }
}
