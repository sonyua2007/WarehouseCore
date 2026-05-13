using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseCore
{
    public class Product
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
                    throw new Exceptions("Помилка :( Ціна не може бути від'ємною.");
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
                    throw new Exceptions("Помилка :( Кількість товару не може бути від'ємною.");
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
        public override string ToString()
        {
            return $"{Brand} {Name} — Ціна: {Price} грн, Залишок: {Quantity} шт.";
        }
    }
}
