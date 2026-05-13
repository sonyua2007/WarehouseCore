using System.Collections.Generic;
using WarehouseCore;

public class ProductService
{
    public static List<Product> Search(List<Product> products, string keyword)
    {
        List<Product> results = new List<Product>();
        foreach (Product product in products)
        {
            if (product.Name.ToLower().Contains(keyword.ToLower()))
            {
                results.Add(product);
            }
        }
        return results;
    }

    public static List<Product> SortByName(List<Product> products)
    {
        List<Product> sorted = new List<Product>(products);
        sorted.Sort((x, y) => x.Name.CompareTo(y.Name));
        return sorted;
    }

    public static List<Product> SortByBrand(List<Product> products)
    {
        List<Product> sorted = new List<Product>(products);
        sorted.Sort((x, y) => x.Brand.CompareTo(y.Brand));
        return sorted;
    }


    public static List<Product> SortByPrice(List<Product> products)
    {
        List<Product> sorted = new List<Product>(products);
        sorted.Sort((x, y) => x.Price.CompareTo(y.Price));
        return sorted;
    }
}
