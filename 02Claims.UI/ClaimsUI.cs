using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02Claims.Lib;

namespace _02Claims.UI
{
    internal class ClaimsUI
    {
        static readonly ClaimRepo _claimRepo = new ClaimRepo();

        static void Main(string[] args)
        {
            // seed - didn't happen last time, probably won't happen here either
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
                        DisplayAllClaims();
                        break;
                    case "2":
                        Console.WriteLine("Which record would you like to see:");
                        int displayRecord = int.Parse(Console.ReadLine());
                        DisplaySingleItem(displayRecord);
                        break;
                    case "3":
                        AddClaim();
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
            Console.WriteLine("Welcome to the Claim (Challenge 02) program, press a key to continue");
            Console.ReadKey();
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu\n\n" +
                "1 - See all claims\n" +
                "2 - Display a claim\n" +
                "3 - Enter new claim\n" +
                "Anything else - Quit\n");
        }

        static void AddClaim()
        {
            Console.Clear();
            Console.WriteLine("Create a new claim\n");

            Console.WriteLine("Enter a claim ID:");
            int userClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the claim type:");
            string userClaimType = Console.ReadLine();

            Console.WriteLine("Enter a claim description:");
            string userClaimDescription = Console.ReadLine();

            Console.WriteLine("Enter a claim amount:");
            double userClaimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the date of the incident: (YYYY-MM-DD)");
            DateTime userDateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the claim: (YYYY-MM-DD)");
            DateTime userDateOfClaim = DateTime.Parse(Console.ReadLine());

            bool itemAdded = _claimRepo.CreateClaim(userClaimID, userClaimType, userClaimDescription, userClaimAmount, userDateOfIncident, userDateOfClaim);

            if (!itemAdded)
                Console.WriteLine("Looks like something went wrong, try again later.");
            else Console.WriteLine("Claim added successfully.");
        }

        static void DisplaySingleItem(int id)
        {
            Console.WriteLine(
                $"Claim ID: {_claimRepo.GetById(id).ClaimId}\n" +
                $"Claim Type: {_claimRepo.GetById(id).ClaimType}\n" +
                $"Description: {_claimRepo.GetById(id).Description}\n" +
                $"Claim Amount: {_claimRepo.GetById(id).ClaimAmount}\n" +
                $"Date of Incident: {_claimRepo.GetById(id).DateOfIncident}\n" +
                $"Date of Claim: {_claimRepo.GetById(id).DateOfClaim}\n");

            if(_claimRepo.GetById(id).IsValid())
                Console.WriteLine("The claim is valid.\n");
            else Console.WriteLine("The claim is invalid.\n");

            Console.ReadKey();
        }

        static void DisplayAllClaims()
        {
            Console.Clear();
            Console.WriteLine("Displaying all claims:\n");
            foreach (var claim in _claimRepo.GetAll())
            {
                DisplaySingleItem(claim.Key);
                Console.WriteLine("Press a key for next record...\n\n\n");
                Console.ReadKey();
            }
        }
    }
}
