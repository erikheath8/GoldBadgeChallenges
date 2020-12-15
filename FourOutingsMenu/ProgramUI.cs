using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FourOutingsRepository;
using static System.Console;

namespace FourOutingsMenu
{
    class ProgramUI
    {
        private OutingsRepository _outingsRepo = new OutingsRepository();

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
                WriteLine("\nSelect a Menu Option:\n" +
                    "1. View All Outings.\n" +
                    "2. Create an Outing.\n" +
                    "3. View Outing Cost By Type.\n" +
                    "4. View Combined Outing Costs.\n" +
                    "0. Exit\n");

                string input = ReadLine();

                switch (input)
                {
                    case "1":
                        ViewOutings();
                        break;
                    case "2":
                        CreateNewOuting();
                        break;
                    case "3":
                        OutingsByTypeCost();
                        break;
                    case "4":
                        OutingsTotalCost();
                        break;
                    case "0":
                        WriteLine("Exiting....\n");
                        Thread.Sleep(1200);
                        keepRunning = false;
                        break;
                    default:
                        WriteLine("Please Enter a Valid Number...\n");
                        break;
                }
                WriteLine("Please Press Any Key To Continue...\n");
                ReadKey();
                Clear();
            }
        }

        //#1 on munu
        public void ViewOutings()
        {
            Clear();
            List<Outings> viewOutingsList = _outingsRepo.GetOutingsList();

            foreach (Outings viewOutings in viewOutingsList)
            {
                WriteLine($"\nOuting Type: {viewOutings.OutingType}" +
                    $"\nNumber of People Attending: {viewOutings.NumOfPeople}" +
                    $"\nOuting Date: {viewOutings.DateOfEvent}" +
                    $"\nCost of the Event: {viewOutings.CostOfEvent}" +
                    $"\nCost Per Person: {viewOutings.CostPerPerson}");
            }
        }

        // #2 on menu
        public void CreateNewOuting()
        {
            Clear();
            Outings newOuting = new Outings();

            WriteLine("\nEnter the Outing Type Number:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");

            int outingTypeInt = Int32.Parse(ReadLine());
            newOuting.OutingType = (OutingType)outingTypeInt;

            WriteLine("\nEnter the Date of the Outing (mm/dd/yy):");
            newOuting.DateOfEvent = ReadLine();

            WriteLine("\nEnter the Number of People Attending:");
            newOuting.NumOfPeople = Int32.Parse(ReadLine());

            WriteLine("\nEnter the Cost Per Person of the Event:");
            newOuting.CostPerPerson = Int32.Parse(ReadLine());

            _outingsRepo.AddOutingsToList(newOuting);

        }

        // #3 on the menu
        public void OutingsByTypeCost()
        {
            Clear();
            WriteLine("\nEnter the Number Type for Outings to View:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");

            string outingTypeInt = ReadLine();

            Double typeCost = 0;
            String typeStr = "";

            switch (outingTypeInt)
            {
                case "1":
                    typeCost = _outingsRepo.GetOutingsByTypeTotal(OutingType.Golf);
                    typeStr = "Golf";
                    break;
                case "2":
                    typeCost = _outingsRepo.GetOutingsByTypeTotal(OutingType.Bowling);
                    typeStr = "Bowling";
                    break;
                case "3":
                    typeCost = _outingsRepo.GetOutingsByTypeTotal(OutingType.AmusementPark);
                    typeStr = "Amusement Park";
                    break;
                case "4":
                    typeCost = _outingsRepo.GetOutingsByTypeTotal(OutingType.Concert);
                    typeStr = "Concert";
                    break;
                case "0":
                    WriteLine("Exiting....\n");
                    Thread.Sleep(1200);
                    break;
            }

            WriteLine($"\n{typeStr} Outings Cost: ${typeCost}");
        }

        public void OutingsTotalCost()
        {
            Clear();
            Double? outingsTotal = _outingsRepo.GetOutingsTotalCost();

            WriteLine($"\n${outingsTotal}");
        }

        //Set content
        public void SetContent()
        {
            Outings outing1 = new Outings(OutingType.AmusementPark, 35, "6/15/2021", 35000, 1000);
            Outings outing2 = new Outings(OutingType.Bowling, 10, "7/15/2021", 1000, 100);
            Outings outing3 = new Outings(OutingType.Concert, 50, "8/31/2021", 15000, 300);

            _outingsRepo.AddOutingsToList(outing1);
            _outingsRepo.AddOutingsToList(outing2);
            _outingsRepo.AddOutingsToList(outing3);
        }


    }
}
