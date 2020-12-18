using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoClaimRespository;

namespace TwoClaimsMenu
{
    class ProgramUI
    {
        private ClaimsRepositiory _claimContent = new ClaimsRepositiory();
        public void Run()
        {
            SetContent();
            Menu();
        }
        private void Menu()
        {
            Queue<Claim> queContent = _claimContent.GetQueue();

            bool keepRunning = true;
            while (keepRunning)
            {
                //display our options to the user
                Console.WriteLine("\nSelect a Menu Option:\n" +
                    "1. See All Claims.\n" +
                    "2. Take Care of Next Claim.\n" +
                    "3. Enter a New Claim.\n" +
                    "4. Exit.\n");

                // get the user's input
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // see all claims
                        QueueContents(queContent);
                        break;
                    case "2":
                        // take care of next claim
                        HandleNextClaim();
                        break;
                    case "3":
                        // enter a new claim
                        CreateNewClaim();
                        break;
                    case "4":
                        // exit
                        Console.WriteLine("Exiting Now...");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Number.");
                        break;
                }
                Console.WriteLine("Press Any Key to Continue...\n");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void QueueContents(Queue<Claim> localQueue)
        {
            Queue<Claim> copyOfClaim = new Queue<Claim>(localQueue);

            string t1 = "ID# ";
            string t2 = "Type";
            string t3 = "Description";
            string t4 = "Amount";
            string t5 = "DateOfIncident";
            string t6 = "DateOfClaim";
            string t7 = "IsValid";

            Console.Clear();
            Console.WriteLine($"\n{t1,-5} {t2,-5} {t4,-7} {t5,-12} {t6,-10} {t7,-10} {t3,-20}");
            
            foreach (Claim claim in copyOfClaim)
           {
                Console.WriteLine($"\n{claim.ClaimID} {claim.ClaimType, 8}  {claim.Amount,-8} {claim.DateOfIncident,-15}" +
                    $" {claim.DateOfClaim,-10} {claim.IsValid,-10} {claim.Description,-20}");
            }
        }
        private void HandleNextClaim()
        {
            Console.Clear();
            Queue<Claim> queContent = _claimContent.GetQueue();

            foreach (Claim claim in queContent)
            {
                Console.WriteLine($"\nClaimID: " + claim.ClaimID);
                Console.WriteLine($"\nType: " + claim.ClaimType);
                Console.WriteLine($"\nDescription: " + claim.Description);
                Console.WriteLine($"\nAmount: " + claim.Amount);
                Console.WriteLine($"\nDate Of Incident: " + claim.DateOfIncident);
                Console.WriteLine($"\nDate Of Claim: " + claim.DateOfClaim);
                Console.WriteLine($"\nIs Valid Claim: \n" + claim.IsValid);
                Console.WriteLine("\nDo You Want to Work on this Claim Now? (Yes/No)");
                string decision = Console.ReadLine().ToLower();

               switch (decision)
                {
                    case "yes":
                        Console.WriteLine($"\nTaking Que # {claim.ClaimID} Off the Queue List.");
                        goto claimRemoval;
                    case "no":
                        continue;
                }

            }
        claimRemoval: queContent.Dequeue();
        }

        private void CreateNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            // get the claim ID
            Console.WriteLine("\nEnter the Claim ID Number:");
            newClaim.ClaimID = Int16.Parse(Console.ReadLine());

            // get the type
            Console.WriteLine("\nEnter the Type of Claim (Car, Home, Theft):");
            newClaim.ClaimType = Console.ReadLine();

            // get the Description 
            Console.WriteLine("\nEnter a Short Description of Claim:");
            newClaim.Description = Console.ReadLine();

            // get the amount of the claim
            Console.WriteLine("\nEnter the Amount of the Claim:");
            newClaim.Amount = Double.Parse(Console.ReadLine());

            // date of the incident
            Console.WriteLine("\nEnter the Date of the Incident in \"mm/dd/yy\":");
            newClaim.DateOfClaim = Console.ReadLine();

            Console.WriteLine("\nEnter if the Claim Is \"Valid\" with \"Yes\" or \"No\":");
            string _IsValid = Console.ReadLine().ToLower();

            if (_IsValid == "yes")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }
            _claimContent.AddContentToQue(newClaim);
        }

        // Helper Methods
        private void SetContent()
        {
            Queue<Claim> setQueue = new Queue<Claim>();

            Claim one = new Claim(1, "Car", "Car Accident on 465.", 400.00, "4/25/18", "4/27/18", true);
            Claim two = new Claim(2, "Home", "House fire in kitchen.", 4000.00, "4/11/18", "4/12/18", true);
            Claim three = new Claim(3, "Theft", "Stolen pancakes.", 4.00, "4/27/18", "6/01/18", false);

            setQueue.Enqueue(one);
            setQueue.Enqueue(two);
            setQueue.Enqueue(three);

            _claimContent.CopyContentQue(setQueue);
        }
           
    }
}

