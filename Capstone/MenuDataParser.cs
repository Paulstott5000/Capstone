using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Capstone.FoodItems;
using Capstone.OrderMenu;

namespace Capstone
{
    internal class MenuDataParser
    {
        public static List<FoodItem> ParseMenuData(string filePath)
        {
            List<FoodItem> menuItems = new List<FoodItem>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                string name = null;
                List<string> toppings = null;
                List<string> garnishes = null;
                string price = null;

                foreach (string line in lines)
                {  
                    if (line.StartsWith("Pizza:"))
                    {
                        name = line.Substring("Pizza:<Name:".Length, line.IndexOf(",Toppings:") - "Pizza:<Name:".Length);
                        toppings = ParseItems(line.Substring(line.IndexOf("Toppings:[") + 10, line.IndexOf("],Price:") - (line.IndexOf("Toppings:[") + 10)));
                        garnishes = new List<string>(); // pizzas don't have garnishes so is left blank

                        price = line.Substring(line.IndexOf("],Price:") - (line.IndexOf("Price:[") - 7));
                        price = price.TrimEnd('>');

                        menuItems.Add(new FoodItem { Name = name, Toppings = toppings, Garnishes = garnishes, Price = double.Parse(price) / 100 });
                    }

                    else if (line.StartsWith("Burger:"))
                    {
                        name = line.Substring("Burger:<Name:".Length, line.IndexOf(",Garnishes:") - "Burger:<Name:".Length);
                        garnishes = ParseItems(line.Substring(line.IndexOf("Garnishes:[") + 11, line.IndexOf("],Price:") - (line.IndexOf("Garnishes:[") + 11)));
                        toppings = new List<string>(); // burgers don't have toppings so is left blank

                        price = line.Substring(line.IndexOf("],Price:") - (line.IndexOf("Price:[") - 7));
                        price = price.TrimEnd('>');

                        menuItems.Add(new FoodItem { Name = name, Toppings = toppings, Garnishes = garnishes, Price = double.Parse(price)/100 });
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Menu file not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing menu data: {ex.Message}");
            }

            return menuItems;
        }

        private static List<string> ParseItems(string items)
        {
            return items
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(item => item.Trim('<', '>'))
                .ToList();
        }

        public static Dictionary<string, string> ToppingManager()
        {
            // create a dictionary to store toppings and prices in
            Dictionary<string, string> toppingPriceDict = new Dictionary<string, string>();
            try
            {
                string[] lines = File.ReadAllLines("menu.txt");
                foreach (var line in lines)
                {
                    if (line.StartsWith("Toppings:"))
                    {
                        // removes the unneccessary bits
                        string tempLine = line.Replace("Toppings:[", "").Replace("]", "");

                        // split the line by ',<' to get topping-price pairs
                        string[] pairs = tempLine.Split(new string[] { ",<" }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string pair in pairs)
                        {
                            // seperates the parts with a colon
                            string[] parts = pair.Split(',');

                            // makes sure there are only 2 parts (topping and price)
                            if (parts.Length == 2)
                            {
                                // removes the unneccesary bits
                                string topping = parts[0].Replace("<", "");
                                string price = parts[1].Replace(">", "");

                                // Adds both the topping and the price to the dictionary
                                toppingPriceDict[topping] = price;
                            }
                            else
                            {
                                Console.WriteLine($"Invalid topping-price pair: {pair}");
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Menu file not found.");
            }

            return toppingPriceDict;
        }

        public static Dictionary<string, string> GarnishManager()
        {
            Dictionary<string, string> garnishPriceDict = new Dictionary<string, string>();
            try
            {
                string[] lines = File.ReadAllLines("menu.txt");
                foreach (var line in lines)
                {
                    if (line.StartsWith("Garnishes:"))
                    {
                        string tempLine = line.Replace("Garnishes:[", "").Replace("]", "");

                        string[] pairs = tempLine.Split(new string[] { ",<" }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string pair in pairs)
                        {

                            string[] parts = pair.Split(',');


                            if (parts.Length == 2)
                            {
                                string garnish = parts[0].Replace("<", "");
                                string price = parts[1].Replace(">", "");

                                garnishPriceDict[garnish] = price;
                            }
                            else
                            {
                                Console.WriteLine($"Invalid garnish-price pair: {pair}");
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Menu file not found.");
            }
            return garnishPriceDict;
        }
    }
}