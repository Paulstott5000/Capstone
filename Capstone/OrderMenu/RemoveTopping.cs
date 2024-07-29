using Capstone.OrderMenu;
using Capstone.FoodItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.OrderMenu
{
    internal class RemoveTopping : MenuItem
    {
        private MenuManager _manager;

        public RemoveTopping(MenuManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Remove a topping from your order";
        }

        public override void Select()
        {
            Console.WriteLine("Choose a pizza to remove topping from:");

            // get all the pizzas from the current order
            var pizzas = _manager.FoodItems.OfType<Pizza>().ToList();

            if (pizzas.Any())
            {
                int i = 1;
                // shows each pizzas toppings
                foreach (var pizza in pizzas)
                {
                    Console.WriteLine($"{i}. {pizza.Name} Toppings: {string.Join(",", pizza.Toppings)}");
                    i ++;
                }

                // input to choose which pizza to remove topping from
                int pizzaIndex = ConsoleHelper.GetIntInRange(1, pizzas.Count, "Select a pizza") - 1;

                var chosenPizza = pizzas[pizzaIndex];
                if (chosenPizza.Toppings.Any())
                {
                    i = 0;
                    Console.WriteLine("Choose a topping to remove:");
                    foreach (var topping in chosenPizza.Toppings)
                    {
                        Console.WriteLine($"{i}. {chosenPizza.Toppings[i]}");
                        i ++;
                    }

                    int toppingIndex = ConsoleHelper.GetIntInRange(1, chosenPizza.Toppings.Count, "Select a topping to remove") - 1;

                    // remove the topping from the chosen pizzas list of toppings
                    chosenPizza.Toppings.RemoveAt(toppingIndex);
                    Console.WriteLine("Topping removed from the order.");
                }
                else
                {
                    Console.WriteLine("This pizza has no toppings to remove.");
                }
            }
            else
            {
                Console.WriteLine("No pizzas in the order.");
            }
        }
    }
}