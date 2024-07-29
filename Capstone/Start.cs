using Capstone;
using Capstone.OrderMenu;

namespace Capstone
{
    internal class Start
    {
        private static void Main(string[] args)
        {
            if (File.Exists("menu.txt"))
            {
                List<FoodItem> menuData = MenuDataParser.ParseMenuData("menu.txt");

                Console.WriteLine("Menu:");
                foreach (var item in menuData)
                {
                    Console.WriteLine($"Name: {item.Name}, Toppings: {string.Join(", ", item.Toppings)}, Garnishes: {string.Join(", ", item.Garnishes)}, Price = {item.Price}");
                }

                MenuManager menuManager = new MenuManager();
                FoodManagerMenu menu = new FoodManagerMenu(menuManager, menuData);
                menu.Select();
            }
            else
            {
                Console.WriteLine("Menu file not found.");
            }
        }
    }
}
