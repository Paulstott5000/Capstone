using Capstone.OrderMenu;
using Capstone.FoodItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.OrderMenu
{
    internal class AddToppings : MenuItem
    {
        private MenuManager _manager;

        public AddToppings(MenuManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Add a topping to your order";
        }

        public override void Select()
        {
            var pizzas = _manager.FoodItems.OfType<Pizza>().ToList();

            if (pizzas.Any())
            {
                int i = 1;
                // shows the toppings for each pizza ordered
                foreach (var pizza in pizzas)
                {
                    Console.WriteLine($"{i}. {pizza.Name} Toppings: {string.Join(",", pizza.Toppings)}");
                    i++;
                }

                // input from user for which pizza they want to add a topping to
                int pizzaIndex = ConsoleHelper.GetIntInRange(1, pizzas.Count, "Select a pizza") - 1;
                var chosenPizza = pizzas[pizzaIndex];

                Console.WriteLine("Choose a topping to add:");

                int index = 1;

                // collects the possible toppings that can be added
                var toppings = MenuDataParser.ToppingManager();

                foreach (var topping in toppings)
                {
                    Console.WriteLine($"{index}. {topping.Key} will cost £{double.Parse(topping.Value) / 100}");
                    index++;
                }

                // user selects a topping to add it then adds the topping to the chosen pizzas list of toppings and the price of the chosen topping to the chosen pizzas price
                int toppingIndex = ConsoleHelper.GetIntInRange(1, toppings.Count, "Select a topping") - 1;
                chosenPizza.Toppings.Add(toppings.ElementAt(toppingIndex).Key);
                chosenPizza.Price += (double.Parse(toppings.ElementAt(toppingIndex).Value) / 100);

            }
        }
    }
}