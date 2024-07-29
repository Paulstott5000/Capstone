using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone;

namespace Capstone
{
    internal class FoodItem
    {
        public string Name { get; set; }
        public List<string> Toppings { get; set; }
        public List<string> Garnishes { get; set; }
        public double Price { get; set; }
    }
}
