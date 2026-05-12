using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseCore
{
    public class Supplier : Person
    {
        public string CompanyName { get; set; }
        public Supplier(int id, string firstName, string lastName, string companyName)
            : base(id, firstName, lastName)
        {
            CompanyName = companyName;
        }
        public override string GetDetails()
        {
            return $"Постачальник: {FirstName} {LastName}, Фірма: {CompanyName}";
        }
    }
}
