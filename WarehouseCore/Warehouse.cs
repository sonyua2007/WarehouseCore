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
        public List<Product> GetProductsSortedByName()
        {
            List<Product> products = GetAllProducts();
            products.Sort();
            return products;
        }
        public List<Product> GetProductsSortedByBrand()
        {
            List<Product> products = GetAllProducts();
            products.Sort((x, y) => x.Brand.CompareTo(y.Brand));
            return products;
        }
        public List<Product> GetProductsSortedByPrice()
        {
            List<Product> products = GetAllProducts();
            products.Sort((x, y) => x.Price.CompareTo(y.Price));
            return products;
        }
        public List<Product> SearchProducts(string keyword)
        {
            List<Product> results = new List<Product>();
            List<Product> allProducts = GetAllProducts();
            foreach (Product product in allProducts)
            {
                if (product.Name.ToLower().Contains(keyword.ToLower()))
                    results.Add(product);
            }
            return results;
        }
        public List<Customer> SearchCustomers(string keyword)
        {
            List<Customer> results = new List<Customer>();
            foreach (Customer customer in Customers)
            {
                if (customer.FirstName.ToLower().Contains(keyword.ToLower()) || customer.LastName.ToLower().Contains(keyword.ToLower()))
                    results.Add(customer);
            }
            return results;
        }
        public List<Supplier> SearchSuppliers(string keyword)
        {
            List<Supplier> results = new List<Supplier>();
            foreach (Supplier supplier in Suppliers)
            {
                if (supplier.FirstName.ToLower().Contains(keyword.ToLower()) || supplier.LastName.ToLower().Contains(keyword.ToLower()))
                    results.Add(supplier);
            }
            return results;
        }
    }
}
