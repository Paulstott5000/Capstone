using Capstone.OrderMenu;
using Capstone.FoodItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.OrderMenu
{
    internal class AddGarnishes : MenuItem
    {
        private MenuManager _manager;

        public AddGarnishes(MenuManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Add a garnish to your order";
        }

        public override void Select()
        {
            var burgers = _manager.FoodItems.OfType<Burger>().ToList();

            if (burgers.Any())
            {
                int i = 1;

                foreach (var burger in burgers)
                {
                    Console.WriteLine($"{i}. {burger.Name} Garnishes: {string.Join(",", burger.Garnishes)}");
                    i ++;
                }


                int burgerIndex = ConsoleHelper.GetIntInRange(1, burgers.Count, "Select a burger") - 1;


                var chosenBurger = burgers[burgerIndex];

                Console.WriteLine("Choose a garnish to add:");

                int index = 1;
                var garnishes = MenuDataParser.GarnishManager();
                foreach (var garnish in garnishes)
                {
                    Console.WriteLine($"{index}. {garnish.Key} will cost £{double.Parse(garnish.Value) / 100}");
                    index++;
                }

                int garnishIndex = ConsoleHelper.GetIntInRange(1, garnishes.Count, "Select a garnish") - 1;
                chosenBurger.Garnishes.Add(garnishes.ElementAt(garnishIndex).Key);
                chosenBurger.Price += (double.Parse(garnishes.ElementAt(garnishIndex).Value)/100);

            }
        }
    }
}