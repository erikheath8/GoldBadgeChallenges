using FiveGreetingsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace FiveGreetingsUI
{
   public class ProgramUI
    {
        private readonly GreetingsRepository _greetingsRepo = new GreetingsRepository();

        public void Run()
        {
            SetContent();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // display our options to the user
                WriteLine("\nSelect a Menu Option:\n" +
                    "1. Display All Greetings.\n" +
                    "2. Create a Greeting Individual.\n" +
                    "3. Remove Greeting by Name.\n" +
                    "0. Exit\n");

                // get the user's input
                string input = Console.ReadLine();

                // evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // create new content
                        DisplayAllGreetings();
                        break;
                    case "2":
                        // view all content
                        CreateNewGreeting();
                        break;
                    case "3":
                        // view content by title
                        RemoveGreeting();
                        break;
                    case "0":
                        // exit
                        WriteLine("Exiting...");
                        keepRunning = false;
                        break;
                    default:
                        WriteLine("Please Enter a Valid Number.");
                        break;
                }
                WriteLine("Please Press Any Key to Continue...\n");
                ReadKey();
                Clear();
            }
        }

        private void DisplayAllGreetings()
        {
            Clear();
            List<Greetings> greetings = _greetingsRepo.GetGreetings();

            string fNameTitle = "First Name";
            string lNameTitle = "Last Name";
            string typeTitle = "Type";
            string emailTitle = "Email";

            WriteLine($"\n{fNameTitle, -12} {lNameTitle, -12} {typeTitle, -10} {emailTitle, -10}");

            foreach (Greetings greeting in greetings)
            {
               

                WriteLine($"\n{greeting.FirstName, -12} {greeting.LastName, -12} {greeting.Greeting, -10} {greeting.EmailString, -10}");

            }
        }

        private void CreateNewGreeting()
        {
            Clear();
            Greetings newGreeting = new Greetings();

            WriteLine("\nEnter the Customer's First Name:");
            newGreeting.FirstName = ReadLine();

            WriteLine("\nEnter the Customer's Last Name:");
            newGreeting.LastName = ReadLine();

            WriteLine("\nEnter the Number for the Associated Customer Type" +
                "\n1. Current." +
                "\n2. Past." +
                "\n3. Potential.");

            string tempType = ReadLine();

            int customerType = Int32.Parse(tempType);
            newGreeting.Greeting = (GreetingType)customerType;

            _greetingsRepo.AddGreetingsToList(newGreeting);
        }

        private void RemoveGreeting()
        {
            Clear();
            DisplayAllNames();
            List<Greetings> greetings = _greetingsRepo.GetGreetings();

            WriteLine("\nEnter the First Name of the Customer to Remove.");
            string tempFirst = ReadLine();

            WriteLine("\nEnter the Last Name of the Customer to Remmove.");
            string tempLast = ReadLine();

            _greetingsRepo.RemoveGreetingByName(tempFirst, tempLast);

            WriteLine("Returning to Main Menu...");
            Thread.Sleep(1200);
        }

        //Helper 
        private void DisplayAllNames()
        {
            Clear();
            List<Greetings> greetings = _greetingsRepo.GetGreetings();

            foreach(Greetings greeting in greetings)
            {
                WriteLine($"\nCustomer First Name: {greeting.FirstName}" +
                    $"\nCustomer Last Name: {greeting.LastName}");
            }

        }

        private void SetContent()
        {
            Greetings person1 = new Greetings("Don", "Pablo", GreetingType.current, "");
            Greetings person2 = new Greetings("Jack", "Ryan", GreetingType.past, "");
            Greetings person3 = new Greetings("Lucie", "Smith", GreetingType.potential, "");

            _greetingsRepo.AddGreetingsToList(person1);
            _greetingsRepo.AddGreetingsToList(person2);
            _greetingsRepo.AddGreetingsToList(person3);
        }

    }
}
