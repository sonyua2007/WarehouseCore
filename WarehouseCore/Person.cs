using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseCore
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        protected Person(int id, string firstName, string lastName) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public abstract string GetDetails();
    }
}
