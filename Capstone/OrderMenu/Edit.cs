using Capstone.OrderMenu;
using Capstone.FoodItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.OrderMenu
{
    internal class EditOrder : ConsoleMenu
    {
        private MenuManager _manager;

        public EditOrder(MenuManager manager)
        {
            _manager = manager;
        }
        public override string MenuText()
        {
            return "Edit order";
        }
        public override void CreateMenu()
        {
            _menuItems.Clear();
        }
    }
}
