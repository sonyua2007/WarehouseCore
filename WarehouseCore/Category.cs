using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseCore
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public Category(int id, string name)
        {
            ID = id;
            Name = name;
            Products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
    }
}
