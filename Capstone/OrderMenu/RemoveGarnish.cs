using Capstone.OrderMenu;
using Capstone.FoodItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.OrderMenu
{
    internal class RemoveGarnishes : MenuItem
    {
        private MenuManager _manager;

        public RemoveGarnishes(MenuManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Remove a garnish from your order";
        }

        public override void Select()
        {
            Console.WriteLine("Choose a garnish to remove:");

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
                if (chosenBurger.Garnishes.Any())
                {
                    i = 0;
                    Console.WriteLine("Choose a garnish to remove:");
                    foreach (var garnish in chosenBurger.Garnishes)
                    {
                        Console.WriteLine($"{i}. {chosenBurger.Garnishes[i]}");
                        i ++;
                    }

                    int garnishIndex = ConsoleHelper.GetIntInRange(1, chosenBurger.Garnishes.Count, "Select a garnish to remove") - 1;

                    chosenBurger.Garnishes.RemoveAt(garnishIndex);
                    Console.WriteLine("Garnish removed from the order.");
                }

                else
                {
                    Console.WriteLine("This burger has no garnishes to remove.");
                }
            }
            else
            {
                Console.WriteLine("No burgers in the order.");
            }
        }
    }
}