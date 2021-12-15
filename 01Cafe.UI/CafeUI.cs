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
                        // delete
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
            Console.Clear();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Menu\n\n" +
                "1 - Add a meal item\n" +
                "2 - Delete a meal item\n" +
                "3 - See all items\n");
        }

        public void AddItem()
        {
            Console.Clear();
            bool itemDone = false;

            while(!itemDone)
            {
                Console.WriteLine("Add an item\n");
                
                Console.WriteLine("Enter a meal number:");
                int userMealNumber = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter meal name:");
                string userName = Console.ReadLine();
                
                Console.WriteLine("Enter a description:");
                string userDescription = Console.ReadLine();
                
                List<string> ingredients = GetIngredientList();

                Console.WriteLine("Enter a price:");
                double userPrice = double.Parse(Console.ReadLine());

                // stopped here - all this bullshit should probably be in the repo
            }
        }

        public List<string> GetIngredientList()
        {
            List<string> userIngredients = new List<string>();

            bool finished = false;
            while(!finished)
            {
                Console.WriteLine("Enter an ingredient:");
                userIngredients.Add(Console.ReadLine());

                Console.WriteLine("Finished? (Y/N)");
                string userFinished = Console.ReadLine();
                if (userFinished == "Y" || userFinished == "y")
                {
                    finished = true;
                }
            }
            return userIngredients;
        }
    }
}
