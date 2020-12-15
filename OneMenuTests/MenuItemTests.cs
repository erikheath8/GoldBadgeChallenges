using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneMenuRepository;

namespace OneMenuTests
{
    [TestClass]
    public class MenuItemTests
    {
        private MenuRepository _testMenuRepo;

        [TestMethod]
        public void AddMenuItemsTest()
        {
            _testMenuRepo = new MenuRepository();

            MenuItem addMenuItem = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 1);

            _testMenuRepo.AddMenuItem(addMenuItem);

            MenuItem itemName = _testMenuRepo.GetByItemName("Tie Burger");

            string ItemNameActual = itemName.ItemName;
            string ItemNameExpected = addMenuItem.ItemName;

            Assert.AreEqual(ItemNameExpected, ItemNameActual);
        }

        [TestMethod]
        public void GetItemMenuListTest()
        {
            _testMenuRepo = new MenuRepository();

            MenuItem testMenuItem = new MenuItem("Burger", "Flavored Burger", new List<string> {"1/4LB Beef",
            "Cheese", "Ketchup"}, 11.50, 3);

            List<MenuItem> testItemList = new List<MenuItem>();
            testItemList.Add(testMenuItem);

            MenuItem addMenuItem = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 1);

            _testMenuRepo.AddMenuItem(addMenuItem);
                        
            List<MenuItem> testList = _testMenuRepo.GetMenuItemList();

            Assert.AreNotEqual(testList, testItemList);
        }

        [TestMethod]
        public void CopyItemByIdToIdNumTest()
        {
            _testMenuRepo = new MenuRepository();

            MenuItem addMenuItem = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 1);

            MenuItem addMenuItem1 = new MenuItem("Supreme Pizza", "Hand Tossed, Wood Fired Hand Pizza", new List<string> { "Medium Hand Tossed Crust",
            "Cheese", "Tomato Sauce", "Pepporoni", "Suasage", "Black Olives"}, 15.75, 2);

            _testMenuRepo.AddMenuItem(addMenuItem);
            _testMenuRepo.AddMenuItem(addMenuItem1);

            _testMenuRepo.CopyItemByIdToIdNum(1, 2);

            MenuItem isMenuItem1 = _testMenuRepo.GetByItemNumber(2);

            string isMenuItem1Str = isMenuItem1.ItemName;
            string blankMenuItemStr = addMenuItem.ItemName;

            Assert.AreNotEqual(isMenuItem1Str, blankMenuItemStr);
            
        }

        [TestMethod]
        public void UpdateExistingIdTest()
        {
            _testMenuRepo = new MenuRepository();

            MenuItem addMenuItem = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 1);

            MenuItem addMenuItem1 = new MenuItem("Supreme Pizza", "Hand Tossed, Wood Fired Hand Pizza", new List<string> { "Medium Hand Tossed Crust",
            "Cheese", "Tomato Sauce", "Pepporoni", "Suasage", "Black Olives"}, 15.75, 1);

            _testMenuRepo.AddMenuItem(addMenuItem);

            bool ifTrue = _testMenuRepo.UpdateExistingId(1, addMenuItem1);

            MenuItem isMenuItem = _testMenuRepo.GetByItemNumber(1);

            string isMenuItemStr = isMenuItem.ItemName;

            Assert.AreEqual(isMenuItemStr, "Supreme Pizza");
        }

        [TestMethod]
        public void UpdateExistingNameTest()
        {
            _testMenuRepo = new MenuRepository();

            MenuItem addMenuItem = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 1);

            MenuItem addMenuItem1 = new MenuItem("Supreme Pizza", "Hand Tossed, Wood Fired Hand Pizza", new List<string> { "Medium Hand Tossed Crust",
            "Cheese", "Tomato Sauce", "Pepporoni", "Suasage", "Black Olives"}, 15.75, 2);

            _testMenuRepo.AddMenuItem(addMenuItem);

            bool ifTrue = _testMenuRepo.UpdateExistingName("Tie Burger", addMenuItem1);

            MenuItem isMenuItem = _testMenuRepo.GetByItemName("Supreme Pizza");

            string isMenuItemStr = isMenuItem.ItemName;
            string actualItemName = addMenuItem1.ItemName;

            Assert.AreEqual(isMenuItemStr, actualItemName);
           
        }

        [TestMethod]
        public void RemoveMenuItemByIdTest()
        {
            _testMenuRepo = new MenuRepository();

            MenuItem addMenuItem = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 1);

            _testMenuRepo.AddMenuItem(addMenuItem);

            bool ifTrue = _testMenuRepo.RemoveMenuItemById(1);

            Assert.IsTrue(ifTrue);
        }

        [TestMethod]
        public void RemoveMenuItemByNameTest()
        {
            _testMenuRepo = new MenuRepository();

            MenuItem addMenuItem = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 1);

            _testMenuRepo.AddMenuItem(addMenuItem);

            _testMenuRepo.RemoveMenuItemByName("Tie Burger");

            MenuItem isMenuItem = _testMenuRepo.GetByItemName("Tie Burger");

            Assert.IsNull(isMenuItem);
        }

        [TestMethod]
        public void GetByItemNameTest() {

            _testMenuRepo = new MenuRepository();

            MenuItem addMenuItem = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 1);

            _testMenuRepo.AddMenuItem(addMenuItem);

            MenuItem isMenuItem = _testMenuRepo.GetByItemName("Tie Burger");

            string isMenuItemStr = isMenuItem.ItemName;

            Assert.AreEqual(isMenuItemStr, "Tie Burger");
        }

        [TestMethod]
        public void GetByItemNumberTest()
        {
            _testMenuRepo = new MenuRepository();

            MenuItem addMenuItem = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 1);

            _testMenuRepo.AddMenuItem(addMenuItem);

            MenuItem isMenuItem = _testMenuRepo.GetByItemNumber(1);

            string isMenuItemStr = isMenuItem.ItemName;

            Assert.AreEqual(isMenuItemStr, "Tie Burger");
        }

        [TestMethod]
        public void GetItemNameCountTest()
        {
            _testMenuRepo = new MenuRepository();

            MenuItem addMenuItem = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 1);

            MenuItem addMenuItem1 = new MenuItem("Supreme Pizza", "Hand Tossed, Wood Fired Hand Pizza", new List<string> { "Medium Hand Tossed Crust",
            "Cheese", "Tomato Sauce", "Pepporoni", "Suasage", "Black Olives"}, 15.75, 2);

            _testMenuRepo.AddMenuItem(addMenuItem);
            _testMenuRepo.AddMenuItem(addMenuItem1);

            int isMenuItemCount = _testMenuRepo.GetItemNameCount();

            Assert.AreEqual(isMenuItemCount, 2);
        }

        [TestMethod]
        public void SetMenuIdTest()
        {
            _testMenuRepo = new MenuRepository();

            MenuItem addMenuItem = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 0);

            MenuItem addMenuItem1 = new MenuItem("Supreme Pizza", "Hand Tossed, Wood Fired Hand Pizza", new List<string> { "Medium Hand Tossed Crust",
            "Cheese", "Tomato Sauce", "Pepporoni", "Suasage", "Black Olives"}, 15.75, 0);

            _testMenuRepo.AddMenuItem(addMenuItem);
            _testMenuRepo.AddMenuItem(addMenuItem1);

            _testMenuRepo.SetMenuId();

            MenuItem menuItem = _testMenuRepo.GetByItemNumber(1);

            int isMenuItemNum = menuItem.MenuNum;

            Assert.AreEqual(isMenuItemNum, 1);

        }

    }
}
