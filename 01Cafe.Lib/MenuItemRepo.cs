using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Cafe.Lib
{
    public class MenuItemRepo
    {
        private readonly Dictionary<int, MenuItem> _menuItems = new Dictionary<int, MenuItem>();

        public bool CreateMenuItem(MenuItem menuItem)
        {
            if (menuItem != null && !_menuItems.ContainsKey(menuItem.MealNumber))
            {
                _menuItems.Add(menuItem.MealNumber, menuItem);
                return true;
            }
            return false;
        }

        public bool CreateMenuItem()
        {
            Console.WriteLine("Add an item to the menu\n");

            int mealNumber = GetMealNumber();

            Console.WriteLine("Enter meal name:");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter a description:");
            string userDescription = Console.ReadLine();

            List<string> ingredients = GetIngredientList();

            Console.WriteLine("Enter a price:");
            double userPrice = double.Parse(Console.ReadLine());

            MenuItem menuItem = new MenuItem(mealNumber, userName, userDescription, ingredients, userPrice);
            
            _menuItems.Add(menuItem.MealNumber, menuItem);

            if (GetById(mealNumber) != null)
                return true;
            else
                return false;
        }

        public int GetMealNumber()
        {
            bool numValid = false;
            int userMealNumber = 0;
            while (!numValid)
            {
                Console.WriteLine("Enter a meal number:");
                userMealNumber = int.Parse(Console.ReadLine());
                
                if (_menuItems.ContainsKey(userMealNumber))
                    Console.WriteLine($"{userMealNumber} is already in use, please pick a different number.");
                else
                    numValid = true;
            }
            return userMealNumber;
        }

        public List<string> GetIngredientList()
        {
            List<string> userIngredients = new List<string>();

            bool finished = false;
            while (!finished)
            {
                Console.WriteLine("Enter an ingredient:");
                userIngredients.Add(Console.ReadLine());

                Console.WriteLine("Finished? (Y/N)");
                string userFinished = Console.ReadLine();
                if (userFinished == "Y" || userFinished == "y")
                    finished = true;
            }
            return userIngredients;
        }

        public MenuItem GetById(int id)
        {
            if (_menuItems.ContainsKey(id))
                return _menuItems[id];
            return null;
        }

        public Dictionary<int, MenuItem> GetAll()
        {
            return _menuItems;
        }

        // Update not needed according to assignment

        public bool DeleteById(int id)
        {
            if (_menuItems.ContainsKey(id))
            {
                _menuItems.Remove(id);
                return true;
            }
            return false;
        }
    }
}
