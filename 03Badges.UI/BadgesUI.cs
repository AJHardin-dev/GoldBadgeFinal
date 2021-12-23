using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03Badges.Lib;

namespace _03Badges.UI
{
    internal class BadgesUI
    {
        static readonly BadgeRepo _badgeRepo = new BadgeRepo();
        static void Main(string[] args)
        {
            // seed - just in case
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
                        AddBadge();
                        break;
                    case "2":
                        Console.WriteLine("Which record would you like to update:");
                        int updateRecord = int.Parse(Console.ReadLine());
                        DisplaySingleItem(updateRecord);
                        UpdateItem(updateRecord);
                        break;
                    case "3":
                        DisplayAllBadges();
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
            Console.WriteLine("Welcome to the Badge (Challenge 03) program, press a key to continue");
            Console.ReadKey();
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu\n\n" +
                "1 - Add a badge\n" +
                "2 - Edit a badge\n" +
                "3 - List all badges\n" +
                "Anything else - Quit\n");
        }

        static void AddBadge()
        {
            Console.Clear();
            Console.WriteLine("Create a new badge\n");

            Console.WriteLine("Enter a badge ID:");
            int userBadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the list of accessible doors:");
            string userDoorNames = Console.ReadLine();

            Console.WriteLine("Enter a badge name:");
            string userBadgeName = Console.ReadLine();

            bool itemAdded = _badgeRepo.CreateBadge(userBadgeID, userDoorNames, userBadgeName);
            if (itemAdded)
                Console.WriteLine("Item updated successfully.");
            else Console.WriteLine("Something went wrong, try again later.");
        }

        static void DisplaySingleItem(int id)
        {
            Console.WriteLine(
                $"Badge ID: {_badgeRepo.GetById(id).BadgeId}\n" +
                $"Accessible Doors: {_badgeRepo.GetById(id).DoorNames}\n" +
                $"Badge Name: {_badgeRepo.GetById(id).BadgeName}\n");
        }

        static void UpdateItem(int id)
        {
            Console.WriteLine("Please enter a new value for doors:");
            string userDoorNames = Console.ReadLine();

            Console.WriteLine("Please enter a new name:");
            string userBadgeName = Console.ReadLine();

            bool itemUpdate = _badgeRepo.UpdateBadgeById(new Badge(id, userDoorNames, userBadgeName));
            if (itemUpdate)
                Console.WriteLine("Item updated successfully.");
            else Console.WriteLine("Something went wrong, try again later.");
            Console.ReadKey();
        }

        static void DisplayAllBadges()
        {
            Console.Clear();
            Console.WriteLine("Displaying all badges:\n");
            foreach (var badge in _badgeRepo.GetAll())
            {
                DisplaySingleItem(badge.Key);
                Console.WriteLine("Press a key for next record...\n\n\n");
                Console.ReadKey();
            }
        }
    }
}
