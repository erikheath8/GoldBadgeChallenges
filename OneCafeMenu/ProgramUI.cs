using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using OneMenuRepository;
using System.Threading;

namespace OneCafeMenu
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SetContent();
            Menu();
        }
        private void Menu()
        {
            bool keepRuning = true;
            while (keepRuning)
            {
                _menuRepo.SetMenuId();

                WriteLine("!Attention!: Program Automatically Puts New ADDED Menu Items at the End of List.\n" +
                    " - All New Created Menu Items will start at the Menu Id: #4 then increase in number.\n" +
                    " - To Move a Menu Item At an Existing ID #, Use Menu Option #7 to \"Move Item By ID to...\"\n" +
                    " - !Menu Option #7 Deletes Menu Item at Original ID # and Overwrites Menu Item @ Destination #.");

                WriteLine("\nSelect a Menu Option:\n" +
                    " 1. View All Menu Options\n" +
                    " 2. Create a Menu Option\n" +
                    " 3. Remove a Menu Option by Menu Number\n" +
                    " 4. Remove a Menu Option by Menu Name\n" +
                    " 5  Update a Menu Item by ID Number\n" +
                    " 6  Update a Menu Item by Name\n" +
                    " 7  Move Item By ID To Overwrite an ID Number\n" +
                    " 0. Exit\n");

                string input = ReadLine();

                switch (input)
                {
                    case "1":
                        // view all menu options
                        DisplayMenuItems();
                        break;
                    case "2":
                        // create a menu option
                        CreateMenuItem();
                        break;
                    case "3":
                        // delete by menu number
                        RemoveMenuItemById();
                        break;
                    case "4":
                        // delete menu option
                        RemoveMenuItemByName();
                        break;
                    case "5":
                        // Update Item by ID
                        UpdateItemById();
                        break;
                    case "6":
                        // Update Item by Name
                        UpdateItemByName();
                        break;
                    case "7":
                        // Copy Item to Another Menu Location
                        CopyIdFromToId();
                        break;
                    case "0":
                        // exit
                        WriteLine("Exiting...\n");
                        Thread.Sleep(1200);
                        keepRuning = false;
                        break;
                    default:
                        WriteLine("Please Enter a Valid Number.");
                        break;
                }
                WriteLine("Press Any Key to Continue...\n");
                ReadKey();
                Clear();
            }
        }

        // #1 on the menu
        private void DisplayMenuItems()
        {
            //_menuRepo.SetMenuId();

            Clear();

            List<MenuItem> menuItems = _menuRepo.GetMenuItemList();

            //int counter = 1;

            foreach (MenuItem menuItem in menuItems)
            {
                WriteLine($"#{menuItem.MenuNum}: {menuItem.ItemName}\n" +
                    $"\nDescription: {menuItem.Description}\n" +
                    $"\nIngrediants:");

                //counter++;

                foreach (String ingrediant in menuItem.Ingrediants)
                {
                    WriteLine($"- {ingrediant}");
                }

                WriteLine($"\nPrice: ${menuItem.Price}\n\n");
            }
        }

        // #2 on the menu
        private void CreateMenuItem()
        {
            List<MenuItem> newItem = new List<MenuItem>();

            List<string> _ingrediants = new List<string>();

            Clear();
            WriteLine("\nEnter a Price for Item.");
            int menuNumber = Int32.Parse(ReadLine());

            WriteLine("\nEnter the Item's Name.");
            string menuName = ReadLine();

            WriteLine("\nEnter the Item's Description.");
            string itemDesc = ReadLine();

            WriteLine("\nEnter an Ingrediant to Add to the List.");
            string itemList = ReadLine();
            _ingrediants.Add(itemList);

            bool keepInput = true;
            while (keepInput)
            {
                WriteLine("\nDo You Want to Add Additional Ingrediants to the List? Enter: Yes or No.");
                string input = ReadLine().ToLower();

                switch (input)
                {
                    case "yes":
                        WriteLine("\nEnter an Ingrediant to Add to the List.");
                        string itemList1 = ReadLine();
                        _ingrediants.Add(itemList1);
                        break;
                    case "no":
                        WriteLine("\nPrceeding to Item Price.");
                        Thread.Sleep(1200);
                        keepInput = false;
                        break;
                    default:
                        WriteLine("\nPlease Enter a Valid Entry...\n");
                        Thread.Sleep(1200);
                        break;
                }
            }

            WriteLine("\nEnter a Price for Item.");
            double itemPrice = Double.Parse(ReadLine());

            MenuItem newMenuItem = new MenuItem(menuName, itemDesc, _ingrediants, itemPrice, menuNumber);

            _menuRepo.AddMenuItem(newMenuItem);
        }

        // #3 on the Menu
        private void RemoveMenuItemById()
        {
            Clear();

            WriteLine("\nEnter the Menu Item Number to Remove.");
            int menuItemNum = Int32.Parse(ReadLine());

            bool delTrueFalse = _menuRepo.RemoveMenuItemById(menuItemNum);

            if (delTrueFalse == true)
            {
                WriteLine("\nItem was Removed from Menu");
            }
            else
            {
                WriteLine("\nItem was not removed...Try Again.");
            }

        }

        // #4 on the menu
        private void RemoveMenuItemByName()
        {
            Clear();

            WriteLine("\nEnter the Item Name to Remove:\n");
            string itemName = ReadLine();

            bool delTrueFalse = _menuRepo.RemoveMenuItemByName(itemName);

            if (delTrueFalse == true)
            {
                WriteLine("\nItem was Removed from Menu");
            }
            else
            {
                WriteLine("\nItem was not removed...Try Again.");
            }
        }

        // #5 on the menu 
        private void UpdateItemById()
        {
            Clear();

            MenuItem newMenuItemObj = new MenuItem();

            List<string> newMenuIngrediants = new List<string>();

            WriteLine("\nEnter a Menu Id to Update.");
            int menuNum = Int32.Parse(ReadLine());

            MenuItem oldMenuItem = _menuRepo.GetByItemNumber(menuNum);

            string menuItemName = oldMenuItem.ItemName;
            string menuDescription = oldMenuItem.Description;

            List<string> oldMenuIngrediants = new List<string>(oldMenuItem.Ingrediants);
            double oldMenuPrice = oldMenuItem.Price;

            WriteLine($"\nCurrent Menu Name: \"{menuItemName}\". \nEnter an Updated Menu Name:");
            string newMenuName = ReadLine();
            newMenuItemObj.ItemName = newMenuName;

            WriteLine($"\nCurrent Menu Description: \"{menuDescription}\"" +
                $"\nEnter a New Menu Description:");
            string newMenuDesc = ReadLine();
            newMenuItemObj.Description = newMenuDesc;

            WriteLine("\nCurrent List of Ingrediants:\n");

            foreach (String itemDesc in oldMenuIngrediants)
            {
                WriteLine($"Current Ingreadiant: - {itemDesc}");
            }

            WriteLine("\nEnter a New Ingrediant.");
            string newIngrediant = ReadLine();
            newMenuIngrediants.Add(newIngrediant);

            bool keepInupt = true;
            while (keepInupt)
            {
                WriteLine("\nDo You Want to ADD Additional Ingrediants? (Yes\\No)");
                string input = ReadLine().ToLower();

                switch (input)
                {
                    case "yes":
                        WriteLine("\nEnter a New Ingrediant.");
                        string newIngrediant1 = ReadLine();
                        newMenuIngrediants.Add(newIngrediant1);
                        break;
                    case "no":
                        WriteLine("\nExiting...");
                        keepInupt = false;
                        break;
                    default:
                        WriteLine("\nInvalid Entry. Enter a Valid Entry.\n");
                        Thread.Sleep(1200);
                        break;
                }
            }

            newMenuItemObj.Ingrediants = new List<string>(newMenuIngrediants);

            WriteLine($"\nCurrent Menu Price: ${oldMenuPrice}" +
                $"\nEnter a New Price.");
            Double newMenuPrice = Double.Parse(ReadLine());
            newMenuItemObj.Price = newMenuPrice;

            newMenuItemObj.MenuNum = 0;

            bool ifUpdateId = _menuRepo.UpdateExistingId(menuNum, newMenuItemObj);

            if (ifUpdateId == true)
            {
                WriteLine("\nMenu Item was Sucessfully Updated");
            }
            else
            {
                WriteLine("\nMenu Item was !NOT Sucessfully Updated");
            }
        }

        // #6 on the menu
        private void UpdateItemByName()
        {
            Clear();

            MenuItem newMenuItemObj = new MenuItem();

            List<string> newMenuIngrediants = new List<string>();

            WriteLine("\nEnter a Menu Name to Update.");
            string menuName = ReadLine();

            MenuItem menuItemNameObj = _menuRepo.GetByItemName(menuName);

            string oldMenuItemName = menuItemNameObj.ItemName;
            string oldMenuDescription = menuItemNameObj.Description;
            List<string> oldMenuIngrediants = new List<string>(menuItemNameObj.Ingrediants);
            double oldMenuPrice = menuItemNameObj.Price;
            int oldMenuId = menuItemNameObj.MenuNum;

            WriteLine($"\nCurrent Menu Name: \"{oldMenuItemName}\". \nEnter an Updated Menu Name:");
            string newMenuName = ReadLine();
            newMenuItemObj.ItemName = newMenuName;

            WriteLine($"\nCurrent Menu Description: \"{oldMenuDescription}\"" +
                $"\nEnter a New Menu Description:");
            string newMenuDesc = ReadLine();
            newMenuItemObj.Description = newMenuDesc;

            WriteLine("\nCurrent List of Ingrediants:\n");

            foreach (String itemDesc in oldMenuIngrediants)
            {
                WriteLine($"Current Ingreadiant: - {itemDesc}");
            }

            WriteLine("\nEnter a New Ingrediant.");
            string newIngrediant = ReadLine();
            newMenuIngrediants.Add(newIngrediant);

            bool keepInupt = true;
            while (keepInupt)
            {
                WriteLine("\nDo You Want to ADD Additional Ingrediants? (Yes\\No)");
                string input = ReadLine().ToLower();

                switch (input)
                {
                    case "yes":
                        WriteLine("\nEnter a New Ingrediant.");
                        string newIngrediant1 = ReadLine();
                        newMenuIngrediants.Add(newIngrediant1);
                        break;
                    case "no":
                        WriteLine("\nExiting...");
                        keepInupt = false;
                        break;
                    default:
                        WriteLine("\nInvalid Entry. Enter a Valid Entry.\n");
                        Thread.Sleep(1200);
                        break;
                }
            }

            newMenuItemObj.Ingrediants = new List<string>(newMenuIngrediants);

            WriteLine($"\nCurrent Menu Price: ${oldMenuPrice}" +
                $"\nEnter a New Price.");
            Double newMenuPrice = Double.Parse(ReadLine());
            newMenuItemObj.Price = newMenuPrice;

            newMenuItemObj.MenuNum = 0;

            bool ifUpdateId = _menuRepo.UpdateExistingName(menuName, newMenuItemObj);

            if (ifUpdateId == true)
            {
                WriteLine("\nMenu Item was Sucessfully Updated");
            }
            else
            {
                WriteLine("\nMenu Item was !NOT Sucessfully Updated");
            }
        }

        // #7 Copy Funciton
        private void CopyIdFromToId()
        {
            Clear();
            PrintMenuIdsTwoNames();
            WriteLine("\nWarning! This Action Will Erase the Copied Item at its Orignial #.");
            WriteLine("\nEnter the Menu Id # You Wish to Copy.");
            int oldMenuId = Int32.Parse(ReadLine());

            WriteLine("\nEnter the Menu Id # You Wish to Replace.");
            int newMenuId = Int32.Parse(ReadLine());

            bool ifUpdated = _menuRepo.CopyItemByIdToIdNum(oldMenuId, newMenuId);

            if (ifUpdated == true)
            {
                WriteLine("\nMenu Item was Sucessfully Updated");
            }
            else
            {
                WriteLine("\nMenu Item was !NOT Sucessfully Updated");
            }
        }

        private void SetContent()
        {
            MenuItem menuItem1 = new MenuItem("Brew Burger", "Flame Broiled Beer Flavored Burger", new List<string> {"Wheat Bun", "1/4LB Beef Patty",
            "Cheese", "Ketchup", "Mayo"}, 11.50, 0);

            MenuItem menuItem2 = new MenuItem("Supreme Pizza", "Hand Tossed, Wood Fired Hand Pizza", new List<string> { "Medium Hand Tossed Crust",
            "Cheese", "Tomato Sauce", "Pepporoni", "Suasage", "Black Olives"}, 15.75, 0);

            MenuItem menuItem3 = new MenuItem("Breaded Tenderloin", "Giant, fried and breaded Tenderloin", new List<string> {"Wheat Bun",
                "Deep Fried Pork Tenderloin", "Pickles", "Onions" }, 12.75, 0);

            _menuRepo.AddMenuItem(menuItem1);
            _menuRepo.AddMenuItem(menuItem2);
            _menuRepo.AddMenuItem(menuItem3);

        }

        // helper method
        private void PrintMenuIdsTwoNames() {

         List<MenuItem> menuItems = new List<MenuItem>(_menuRepo.GetMenuItemList());

            WriteLine("\nMenu Id #s and Item Names:\n");

            foreach(MenuItem _menuItem in menuItems)
            {
                WriteLine($"Menu Id: #{_menuItem.MenuNum} {_menuItem.ItemName}\n");

            }
        }

    }
}
