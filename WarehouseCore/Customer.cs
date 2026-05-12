using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseCore
{
    public class Customer : Person
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Customer(int id, string firstName, string lastName, string address, string phoneNumber)
            : base(id, firstName, lastName)
        {
            Address = address;
            PhoneNumber = phoneNumber;
        }
        public override string GetDetails()
        {
            return $"Замовник: {FirstName} {LastName}, Контакти: {PhoneNumber}, Адреса доставки: {Address}";
        }
    }
}
