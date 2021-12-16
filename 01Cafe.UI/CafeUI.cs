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
        private readonly MenuItemRepo _menuItemRepo = new MenuItemRepo();
                
        public void Main(string[] args)
        {
            // seed
            RunProgram();
        }

        public void RunProgram()
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
                        // get all
                        break;
                    default:
                        keepRunning = false;
                        break;
                }

            }
        }

        public void DisplayWelcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the program, press a key to continue");
            Console.ReadKey();
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu\n\n" +
                "1 - Add a meal item\n" +
                "2 - Delete a meal item\n" +
                "3 - See all items\n");
        }

        public void DisplaySingleItem(int id)
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

        public void AddItem()
        {
            Console.Clear();
            bool itemAdded = _menuItemRepo.CreateMenuItem();
            
            if (!itemAdded)
                Console.WriteLine("Looks like something went wrong, try again later.");
        }

        public void DeleteItem()
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
            else
                Console.WriteLine("No meal present with that number");
        }
        
    }
}
