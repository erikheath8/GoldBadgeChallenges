using SixGreenPlanRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace SixGreenPlanMenu
{
    class ProgramUI
    {
        private GreenCarsRepository _greenCarsRepo = new GreenCarsRepository();

        public void Run()
        {
            SetContent();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                WriteLine("\nGreen Car Option Menu Selection:" +
                    "\n1. View All Lists." +
                    "\n2. Create a Listing." +
                    "\n3. Update a Listing by ID #." +
                    "\n4. Remove a Listing by ID #." +
                    "\n0. Exit\n");

                string input = ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayGreenCarsList();
                        break;
                    case "2":
                        CreateGreenCar();
                        break;
                    case "3":
                        UpdateGreenCarById();
                        break;
                    case "4":
                        RemoveGreenCarById();
                        break;
                    case "0":
                        WriteLine("\nExting...");
                        Thread.Sleep(1200);
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

        private void DisplayGreenCarsList()
        {
            Clear();
            List<GreenCars> greenCars = _greenCarsRepo.GetGreenCarsList();

            string idTitle = "ID #";
            string carTypeTitle = "Car Type ";
            string mpgTitle = "MPG ";
            string ticketsTitle = "# Tickets ";
            string milesTitle = "Yearly Miles ";
            string insRateTitle = "Insurance Rate ";
            string carUseTitle = "Primary Use ";

            WriteLine($"\n{idTitle,-2} | {carTypeTitle,-8} | {mpgTitle,-3} | {ticketsTitle,-8} | {milesTitle,-5} | " +
                $"{insRateTitle,-5} | {carUseTitle,-5}");

            foreach (GreenCars greenCar in greenCars) { 

                WriteLine($"\n{greenCar.Id,-8}{greenCar.CarType,-10} {greenCar.Mpg,-9} {greenCar.TrafficTickets,-12}{greenCar.MilesDrivenYr,-15}" +
               $"${greenCar.InsuranceRate,-17}{greenCar.CarUse,-10}");
            }
        }

        private void CreateGreenCar()
        {
            Clear();
            GreenCars newGreenCar = new GreenCars();

            WriteLine("\nEnter the Car Type Number:" +
                "\n1. Gas" +
                "\n2. Hybrid" +
                "\n3. Electric");
            int carTypeNum = Int32.Parse(ReadLine());
            newGreenCar.CarType = (CarType)carTypeNum;

            WriteLine("\nEnter the MPG or Miles Per Charge.");
            int mpgInput = Int32.Parse(ReadLine());
            newGreenCar.Mpg = mpgInput;

            WriteLine("\nEnter # of Traffic Tickets.");
            int ticketsInput = Int32.Parse(ReadLine());
            newGreenCar.TrafficTickets = ticketsInput;

            WriteLine("\nEnter # of Miles Driven Per Year.");
            int milesPerYrInput = Int32.Parse(ReadLine());
            newGreenCar.MilesDrivenYr = milesPerYrInput;

            WriteLine("\nEnter Insurance Rate in Dollars Per Year.");
            double insRateInput = Double.Parse(ReadLine());
            newGreenCar.InsuranceRate = insRateInput;

            WriteLine("\nEnter the Car's Primary Use Associated #:" +
                "\n1. Personal" +
                "\n2. Work" +
                "\n3. Pleasure");
            int carUseNum = Int32.Parse(ReadLine());
            newGreenCar.CarUse = (CarUse)carUseNum;
            
            //Assigned bc num cannot be null in this instance
            newGreenCar.Id = 0;

            _greenCarsRepo.AddGreenCarsToList(newGreenCar);

        }

        private void UpdateGreenCarById()
        {
            Clear();
            WriteLine("\nEnter the Green Car Id to Update.");
            int oldCarIdUpdate = Int32.Parse(ReadLine());

            GreenCars oldGreenCar = _greenCarsRepo.GetGreenCarById(oldCarIdUpdate);

            GreenCars newGreenCar = new GreenCars();

            WriteLine("\nEnter the Car Type Number:" +
                "\n1. Gas" +
                "\n2. Hybrid" +
                "\n3. Electric");
            int carTypeNum = Int32.Parse(ReadLine());
            newGreenCar.CarType = (CarType)carTypeNum;

            WriteLine("\nEnter the MPG or Miles Per Charge.");
            int mpgInput = Int32.Parse(ReadLine());
            newGreenCar.Mpg = mpgInput;

            WriteLine("\nEnter # of Traffic Tickets.");
            int ticketsInput = Int32.Parse(ReadLine());
            newGreenCar.TrafficTickets = ticketsInput;

            WriteLine("\nEnter # of Miles Driven Per Year.");
            int milesPerYrInput = Int32.Parse(ReadLine());
            newGreenCar.MilesDrivenYr = milesPerYrInput;

            WriteLine("\nEnter Insurance Rate in Dollars Per Year.");
            double insRateInput = Double.Parse(ReadLine());
            newGreenCar.InsuranceRate = insRateInput;

            WriteLine("\nEnter the Car's Primary Use Associated #:" +
                "\n1. Personal" +
                "\n2. Work" +
                "\n3. Pleasure");
            int carUseNum = Int32.Parse(ReadLine());
            newGreenCar.CarUse = (CarUse)carUseNum;

            newGreenCar.Id = oldGreenCar.Id;

            bool ifCarUpdated = _greenCarsRepo.UpdateGreenCar(oldCarIdUpdate, newGreenCar);

            if (ifCarUpdated == true)
            {
                WriteLine("\nCar Was Updated.");
            }
            else
            {
                WriteLine("\nCar Was NOT Updated.");
            }
        }

        private void RemoveGreenCarById()
        {
            Clear();
            WriteLine("\nEnter the Green Car Id to Remove.");
            int carIdRemove = Int32.Parse(ReadLine());
            bool ifCarRemoved = _greenCarsRepo.RemoveGreenCarFromList(carIdRemove);

            if (ifCarRemoved == true)
            {
                WriteLine("\nCar Was Removed!");
            }
            else
            {
                WriteLine("\nCar Was NOT Removed!");
            }
        }

        //SetContent
        private void SetContent()
        {
            GreenCars car1 = new GreenCars(CarType.Gas, 37, 2, 12500, 1050.75, CarUse.Personal, 0);
            GreenCars car2 = new GreenCars(CarType.Hybrid, 55, 0, 21050, 1275.95, CarUse.Work, 0);
            GreenCars car3 = new GreenCars(CarType.Electric, 550, 1, 17575, 1525.50, CarUse.Personal, 0);

            _greenCarsRepo.AddGreenCarsToList(car1);
            _greenCarsRepo.AddGreenCarsToList(car2);
            _greenCarsRepo.AddGreenCarsToList(car3);
        }

    }
}
