using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.FoodItems;
using Capstone;

namespace Capstone.OrderMenu
{
    internal class MenuManager
    {
        public List<FoodExtras> FoodItems { get; set; }

        public MenuManager()
        {
            FoodItems = new List<FoodExtras>();
        }

        public void AddFood(FoodExtras pFood)
        {
            FoodItems.Add(pFood);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (FoodExtras pFood in FoodItems)
            {
                sb.Append(pFood.ToString() + Environment.NewLine);
            }
            return sb.ToString();

        }
    }
}
