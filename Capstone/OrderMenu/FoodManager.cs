using Capstone.FoodItems;
using Capstone.OrderMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Capstone;

namespace Capstone.OrderMenu
{
    internal class FoodManagerMenu : ConsoleMenu
    {
        private MenuManager _manager;
        private List<FoodItem> _menuData;
        public FoodManagerMenu(MenuManager manager, List<FoodItem> menuData)
        {
            _manager = manager;
            _menuData = menuData;
        }
        public override void CreateMenu()
        {
            _menuItems.Clear();

            // Filter menuData to find burgers and pizzas
            var burgers = _menuData.Where(item => item.Name.Contains("Burger")).ToList();
            var pizzas = _menuData.Where(item => item.Toppings != null && item.Toppings.Any()).ToList();

            // Add AddBurgerMenuItem and AddPizzaMenuItem if there are burgers and pizzas respectively
            if (burgers.Any())
            {
                _menuItems.Add(new OrderBurger(_manager, burgers));
            }
            if (pizzas.Any())
            {
                _menuItems.Add(new OrderPizza(_manager, pizzas));
            }
            if (_manager.FoodItems.Any(item => item is Burger && ((Burger)item).Price.ToString().Any()))
            {
                _menuItems.Add(new AddGarnishes(_manager));
            }
            if (_manager.FoodItems.Any(item => item is Pizza && ((Pizza)item).Price.ToString().Any()))
            {
                _menuItems.Add(new AddToppings(_manager));
            }
            if (_manager.FoodItems.Any(item => item is Burger && ((Burger)item).Garnishes.Any() && ((Burger)item).Price.ToString().Any()))
            {
                _menuItems.Add(new RemoveGarnishes(_manager));
            }
            if (_manager.FoodItems.Any(item => item is Pizza && ((Pizza)item).Toppings.Any() && ((Pizza)item).Price.ToString().Any()))
            {
                _menuItems.Add(new RemoveTopping(_manager));
            }

            // Add ExitMenu item
            _menuItems.Add(new Exit(this, _manager));
        }

        public override string MenuText()
        {
            //calculates the overall price of the order so that the user knows the price of their order at each stage
            double overallPrice = 0;
            var burgers = _manager.FoodItems.OfType<Burger>().ToList();
            if (burgers.Any())
            {
                foreach (var burger in burgers)
                {
                    overallPrice += burger.Price;
                }
            }
            var pizzas = _manager.FoodItems.OfType<Pizza>().ToList();
            if (pizzas.Any())
            {
                foreach (var pizza in pizzas)
                {
                    overallPrice += pizza.Price;
                }
            }

            return $"Your Order (£{overallPrice}):" + Environment.NewLine + _manager.ToString();
        }
    }
}