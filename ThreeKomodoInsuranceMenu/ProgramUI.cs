using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreeBadgeRepository;
using static System.Console;

namespace ThreeBadgeMenu
{
    class ProgramUI
    {
        private BadgeRepository _BadgeRepository = new BadgeRepository();

        public void Run()
        {
            SeedContent();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\nSelect a Menu Option:\n" +
                    "1. Create a New Badge\n" +
                    "2. Remove A Door Access on a Badge.\n" +
                    "3. Add Door Access on a Badge.\n" +
                    "4. Remove ALL Door Access from a Badge.\n" +
                    "5. Remove Badge from List.\n" +
                    "6. Show List of Badge and Door Access\n" +
                    "0. Exit.\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        RemoveDoor();
                        break;
                    case "3":
                        AddAddtionalDoor();
                        break;
                    case "4":
                        DeleteAllDoors();
                        break;
                    case "5":
                        DeleteId();
                        break;
                    case "6":
                        ShowBadgesAndDoors();
                        break;
                    case "0":
                        WriteLine("Exiting...");
                        keepRunning = false;
                        break;
                    default:
                        WriteLine("Please Enter a Valid Number...\n");
                        Thread.Sleep(1200);
                        break;
                }
                WriteLine("Please Press Any key to Continue...\n");
                ReadKey();
                Clear();
            }
        }

        //#1 on the menu
        private void CreateBadge()
        {
            Clear();
            List<string> newDoors = new List<string>();

            WriteLine("\nPlease Enter the ID for the NEW Badge (1 to 10).");
            int badgeNum = Int32.Parse(ReadLine());

            WriteLine("\nPlease Enter a Door to Be Added to the Badge Access.");
            string newDoorZero = ReadLine();
            newDoors.Add(newDoorZero);

            bool keepInput = true;
            while (keepInput)
            {
                WriteLine("\nDo You Want to Add Additional Doors to the Badge? Input:(Yes/No)");
                string input = ReadLine().ToLower();

                switch (input)
                {
                    case "yes":
                        WriteLine("\nPlease Enter a Door to be Added to the Badge.");
                        string newDoor = ReadLine();
                        newDoors.Add(newDoor);
                        break;
                    case "no":
                        Console.WriteLine("\nExiting...");
                        keepInput = false;
                        break;
                    default:
                        //Console.WriteLine("\nPlease Enter a Valid Entry...\n");
                        //Thread.Sleep(1200);
                        WriteLine("\nInvalid Entry. Please Try Again Next Time. Exiting....");
                        Thread.Sleep(1200);
                        keepInput = false;
                        break;
                }
            }
            Badge BadgeKv = new Badge (badgeNum, newDoors);
            _BadgeRepository.AddContent(badgeNum, BadgeKv);
        }

        //#2 on the menu
        private void RemoveDoor()
        {
            Clear();
            WriteLine("\nPlease Enter the Badge ID to Update.");
            int badgeNum = Int32.Parse(ReadLine());

            WriteLine("\nPlease Enter the Door to be Removed.\n");
            string delDoor = ReadLine();

            _BadgeRepository.RemoveSingleDoor(badgeNum, delDoor);
        }

        // #3 on the menu
        private void AddAddtionalDoor()
        {
            Clear();
            WriteLine("\nPlease Enter the Badge ID to Update.");
            int badgeNum = Int32.Parse(ReadLine());

            WriteLine("\nPlease Enter the Door to be Added.\n");
            string delDoor = ReadLine();

            _BadgeRepository.AddDoor(badgeNum, delDoor);
        }

        //#4 Remove/Delete all Doors from a Badge
        private void DeleteAllDoors()
        {
            Clear();
            WriteLine("\nPlease Enter the Badge ID to Remove ALL Door Access From.");
            int badgeNum = Int32.Parse(ReadLine());

            _BadgeRepository.RemoveAllDoors(badgeNum);

        }

        //#5 Remove Badge
        private void DeleteId()
        {
            Clear();
            WriteLine("\nPlease Enter the Badge ID to Delete.");
            int badgeNum = Int32.Parse(ReadLine());

            _BadgeRepository.RemoveAll(badgeNum);

        }

        //#6 show all badge and doors
        private void ShowBadgesAndDoors()
        {
            Clear();
            Dictionary<int, Badge> keyValuePairs = _BadgeRepository.GetDictionary();

            WriteLine("\nBadges and IDs:");

            foreach (KeyValuePair<int, Badge> _keyValuePairs in keyValuePairs)
            {
                int badgeId = _keyValuePairs.Value.BadgeID;
                List<string> doors = _keyValuePairs.Value.DoorNames;

                WriteLine($"\nBadgeId: {badgeId}");

                foreach(String doorsId in doors)
                {
                    WriteLine($"Doors: {doorsId}");
                }
            }
        }

       private void SeedContent()
       {
            var badge1 = new Badge(1, new List<string> { "A1", "A2", "A3" });
            _BadgeRepository.AddContent(badge1.BadgeID, badge1);

            var badge2 = new Badge(2, new List<string> { "B1", "B2", "B3" });
            _BadgeRepository.AddContent(badge2.BadgeID, badge2);

            var badge3 = new Badge(3, new List<string> { "C1", "C2", "C3" });
            _BadgeRepository.AddContent(badge3.BadgeID, badge3);
        }
       
    }
}
