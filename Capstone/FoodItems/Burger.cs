using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Capstone.OrderMenu;

namespace Capstone.FoodItems
{
    internal class Burger : FoodExtras
    {
        public string Name { get; set; }
        public List<string> Garnishes { get; set; }
        public double Price { get; set; }

        public Burger(string name, List<string> garnishes, double price)
        {
            Name = name;
            Garnishes = garnishes;
            Price = price;
        }

        public override string ToString()
        {
            return $" A {Name} with {string.Join(",", Garnishes)} garnishes. Price £{Price}";
        }
    }
}

