using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseCore
{
    public class Product : IComparable<Product>
    {
        private double price;
        private int quantity;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price 
        { 
            get 
            { 
                return price; 
            } 
            set 
            {
                if (value < 0)
                    throw new WarehouseException("Помилка :( Ціна не може бути від'ємною.");
                price = value; 
            } 
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value < 0)
                    throw new WarehouseException("Помилка :( Кількість товару не може бути від'ємною.");
                quantity = value;
            }
        }

        public Product (int id, string name, string brand, double price, int quantity)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Price = price;
            Quantity = quantity;
        }
        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return this.Name.CompareTo(other.Name);
        }
        public override string ToString()
        {
            return $"{Brand} {Name} — Ціна: {Price} грн, Залишок: {Quantity} шт.";
        }
    }
}
