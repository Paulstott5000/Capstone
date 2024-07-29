using Capstone.FoodItems;
using Capstone.OrderMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone;

namespace Capstone.OrderMenu
{
    internal class OrderBurger : MenuItem
    {
        private MenuManager _manager;
        private List<FoodItem> _burgers;

        public OrderBurger(MenuManager manager, List<FoodItem> burgers)
        {
            _manager = manager;
            _burgers = burgers;
        }

        public override string MenuText()
        {
            return "Add a burger to your order";
        }

        public override void Select()
        {
            Console.WriteLine("Choose a burger:");

            for (int i = 0; i < _burgers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_burgers[i].Name}");
            }

            if (_burgers.Count > 0)
            {
                int selectedIndex = ConsoleHelper.GetIntInRange(1, _burgers.Count, "Select a burger") - 1;

                // creates a new instance of burger with a list of its garnishes
                Burger selectedBurger = new Burger(_burgers[selectedIndex].Name, new List<string>(_burgers[selectedIndex].Garnishes), (_burgers[selectedIndex].Price));
                _manager.AddFood(selectedBurger);
            }
            else
            {
                Console.WriteLine("No burgers available.");
            }
        }
    }
}