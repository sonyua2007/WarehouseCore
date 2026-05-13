using System.Collections.Generic;
using WarehouseCore;

public class PartnerService
{
    public static List<Customer> SearchCustomers(List<Customer> customers, string keyword)
    {
        List<Customer> results = new List<Customer>();
        foreach (Customer customer in customers)
        {
            if (customer.FirstName.ToLower().Contains(keyword.ToLower()) ||
                customer.LastName.ToLower().Contains(keyword.ToLower()))
            {
                results.Add(customer);
            }
        }
        return results;
    }

    public static List<Supplier> SortSuppliersByFirstName(List<Supplier> suppliers)
    {
        List<Supplier> sorted = new List<Supplier>(suppliers);
        sorted.Sort((x, y) => x.FirstName.CompareTo(y.FirstName));
        return sorted;
    }
    public static List<Supplier> SortSuppliersByLastName(List<Supplier> suppliers)
    {
        List<Supplier> sorted = new List<Supplier>(suppliers);
        sorted.Sort((x, y) => x.LastName.CompareTo(y.LastName));
        return sorted;
    }
}
