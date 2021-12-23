using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01Cafe.Lib;

namespace _01Cafe.UI
{
    public class CafeUI
    {
        static readonly MenuItemRepo _menuItemRepo = new MenuItemRepo();
                
        static void Main(string[] args)
        {
            // seed - didn't happen
            RunProgram();
        }

        static void RunProgram()
        {
            DisplayWelcome();

            bool keepRunning = true;
            while (keepRunning)
            {
                DisplayMenu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        DeleteItem();
                        break;
                    case "3":
                        DisplayAllItems();
                        break;
                    default:
                        keepRunning = false;
                        break;
                }
            }
        }

        static void DisplayWelcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Cafe (Challenge 01) program, press a key to continue");
            Console.ReadKey();
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu\n\n" +
                "1 - Add a meal item\n" +
                "2 - Delete a meal item\n" +
                "3 - See all items\n" +
                "Anything else - Quit\n");
        }

        static void DisplaySingleItem(int id)
        {
            string ingredients = "";
            foreach (string ing in _menuItemRepo.GetById(id).Ingredients)
            {
                ingredients.Concat($"{ing} ");
            }

            Console.WriteLine($"Meal Number: {_menuItemRepo.GetById(id).MealNumber}\n" +
                $"Name: {_menuItemRepo.GetById(id).Name}\n" +
                $"Description: {_menuItemRepo.GetById(id).Description}\n" +
                $"Ingredients: {ingredients}\n" +
                $"Price: {_menuItemRepo.GetById(id).Price}");
        }

        static void AddItem()
        {
            Console.Clear();
            Console.WriteLine("Add an item to the menu\n");

            Console.WriteLine("Enter a meal number:");
            int userMealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter meal name:");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter a description:");
            string userDescription = Console.ReadLine();

            List<string> ingredients = GetIngredientList();

            Console.WriteLine("Enter a price:");
            double userPrice = double.Parse(Console.ReadLine());
            
            bool itemAdded = _menuItemRepo.CreateMenuItem(userMealNumber, userName, userDescription, ingredients, userPrice);

            if (!itemAdded)
                Console.WriteLine("Looks like something went wrong, try again later.");
            else Console.WriteLine("Item added successfully.");
        }

        /* keeping this for now
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
        }*/

        static List<string> GetIngredientList()
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

        static void DeleteItem()
        {
            Console.Clear();
            Console.WriteLine("Enter the meal number to be removed:");
            int userDeleteId = int.Parse(Console.ReadLine());
            if (_menuItemRepo.GetById(userDeleteId) != null)
            {
                DisplaySingleItem(userDeleteId);
                Console.WriteLine("Delete item?  Y - Confirm delete / N - Cancel");
                string conf = Console.ReadLine();
                if (conf == "Y" || conf == "y")
                    _menuItemRepo.DeleteById(userDeleteId);
            }
            else Console.WriteLine("No meal present with that number");
        }
        
        static void DisplayAllItems()
        {
            Console.Clear();
            Console.WriteLine("Displaying all meals:\n");
            foreach(var meal in _menuItemRepo.GetAll())
            {
                // Console.Clear();
                DisplaySingleItem(meal.Key);
                Console.WriteLine("Press a key for next record...\n\n\n");
                Console.ReadKey();
            }
        }
    }
}
