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
    internal class OrderPizza : MenuItem
    {
        private MenuManager _manager;
        private List<FoodItem> _pizzas;

        public OrderPizza(MenuManager manager, List<FoodItem> pizzas)
        {
            _manager = manager;
            _pizzas = pizzas;
        }

        public override string MenuText()
        {
            return "Add a pizza to your order";
        }
        public override void Select()
        {
            Console.WriteLine("Choose a pizza:");

            for (int i = 0; i < _pizzas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_pizzas[i].Name}");
            }

            if (_pizzas.Count > 0)
            {
                int selectedIndex = ConsoleHelper.GetIntInRange(1, _pizzas.Count, "Select a pizza") - 1;

                // creates a new instance of pizza with a list of its toppings
                Pizza selectedPizza = new Pizza(_pizzas[selectedIndex].Name, new List<string>(_pizzas[selectedIndex].Toppings), _pizzas[selectedIndex].Price);

                _manager.AddFood(selectedPizza);
            }
            else
            {
                Console.WriteLine("No pizzas available.");
            }
        }
    }
}