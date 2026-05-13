using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseCore
{
    public class Warehouse
    {
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Customer> Customers { get; set; }
        public Warehouse()
        {
            Categories = new List<Category>();
            Suppliers = new List<Supplier>();
            Customers = new List<Customer>();
        }
        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }
        public void RemoveCategory(Category category)
        {
            Categories.Remove(category);
        }
        public void AddSupplier(Supplier supplier)
        {
            Suppliers.Add(supplier);
        }
        public void RemoveSupplier(Supplier supplier)
        {
            Suppliers.Remove(supplier);
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
        public void RemoveCustomer(Customer customer)
        {
            Customers.Remove(customer);
        }
        public List<Product> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>();
            foreach (Category categories in Categories)
            {
                allProducts.AddRange(categories.Products);
            }
            return allProducts;
        }
    }
}
