using Capstone.FoodItems;
using Capstone.OrderMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.OrderMenu
{
    internal class Exit : MenuItem
    {
        private ConsoleMenu _menu;
        private MenuManager _manager;

        public Exit(ConsoleMenu parentItem, MenuManager manager)
        {
            _menu = parentItem;
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Exit";
        }

        public override void Select()
        {
            // creates a blank line and a line saying "New Order:" between each order in the file
            File.AppendAllText("Order.txt", "");
            File.AppendAllText("Order.txt", "New Order:");

            // collects all of the burgers and pizzas from the order
            var burgers = _manager.FoodItems.OfType<Burger>().ToList();
            var pizzas = _manager.FoodItems.OfType<Pizza>().ToList();

            double overallPrice = 0;

            // saves each burger to the order file
            if (burgers.Any())
            {
                foreach (var burger in burgers)
                {
                    overallPrice += burger.Price;
                    var lines = new List<string>
                    {
                        "",
                        $"Name: {burger.Name}",
                        $"Garnishes: {string.Join(", ", burger.Garnishes)}",
                        $"Price: £{burger.Price}"
                    };
                    File.AppendAllLines("Order.txt", lines);
                }
            }

            //saves each pizza to the order file
            if (pizzas.Any())
            {
                foreach (var pizza in pizzas)
                {
                    overallPrice += pizza.Price;
                    var lines = new List<string>
                    {
                        "",
                        $"Name: {pizza.Name}",
                        $"Toppings: {string.Join(", ", pizza.Toppings)}",
                        $"Price: £{pizza.Price}"
                    };
                    File.AppendAllLines("Order.txt", lines);
                }
            }

            // saves the overall price to the order file then outputs the overall price to the user
            File.AppendAllText("Order.txt", $"Your Overall Order costs £{overallPrice}");
            Console.WriteLine($"Your Overall Order costs £{overallPrice}");
            _menu.IsActive = false;
        }
    }
}