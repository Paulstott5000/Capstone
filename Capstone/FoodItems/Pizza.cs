using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Capstone.OrderMenu;

namespace Capstone.FoodItems
{
    internal class Pizza : FoodExtras
    {
        public string Name { get; set; }
        public List<string> Toppings { get; set; }
        public double Price { get; set; }

        public Pizza(string name, List<string> toppings, double price)
        {
            Name = name;
            Toppings = toppings;
            Price = price;
        }

        public override string ToString()
        {
            return $" A {Name} pizza with {string.Join(",", Toppings)} toppings. Price = £{Price}";
        }
    }
}