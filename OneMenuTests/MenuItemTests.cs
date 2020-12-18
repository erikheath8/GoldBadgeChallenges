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

        private string itemNameTie = "Tie Burger";
        private string itemNamePizza = "Supreme Pizza";

        private MenuItem MenuItemTieBurger = new MenuItem("Tie Burger", "Empire Flavored TIE Fighter Burger", new List<string> {"Metal Bun", "1/4LB Tie Beef",
            "Cheese", "Ketchup", "Mayo", "Blasters"}, 14.50, 1);

        private MenuItem menuItemPizza = new MenuItem("Supreme Pizza", "Hand Tossed, Wood Fired Hand Pizza", new List<string> { "Medium Hand Tossed Crust",
            "Cheese", "Tomato Sauce", "Pepporoni", "Suasage", "Black Olives"}, 15.75, 2);

        [TestMethod]
        public void AddMenuItemsTest()
        {
            SetContentOneItem();
            MenuItem itemName = _testMenuRepo.GetByItemName(itemNameTie);
            Assert.IsNotNull(itemName);
        }

        [TestMethod]
        public void GetItemMenuListTest()
        {
            SetContentOneItem();

            MenuItem testMenuItem = new MenuItem("Burger", "Flavored Burger", new List<string> {"1/4LB Beef",
            "Cheese", "Ketchup"}, 11.50, 3);

            List<MenuItem> testItemList = new List<MenuItem>();
            testItemList.Add(testMenuItem);

            List<MenuItem> acutalTestList = _testMenuRepo.GetMenuItemList();

            Assert.AreNotEqual(acutalTestList, testItemList);
        }

        [TestMethod]
        public void CopyItemByIdToIdNumTest()
        {
            SetContentTwoItems();
            
            // This method copies one item to another, leaving the original's values blanks.
            _testMenuRepo.CopyItemByIdToIdNum(MenuItemTieBurger.MenuNum, menuItemPizza.MenuNum);

            MenuItem isMenuItem1 = _testMenuRepo.GetByItemNumber(MenuItemTieBurger.MenuNum);

            Assert.AreNotEqual(isMenuItem1.ItemName, itemNameTie);
        }

        [TestMethod]
        public void UpdateExistingIdTest()
        {
            SetContentOneItem();

            bool ifTrue = _testMenuRepo.UpdateExistingId(MenuItemTieBurger.MenuNum, menuItemPizza);

            MenuItem isMenuItem = _testMenuRepo.GetByItemNumber(MenuItemTieBurger.MenuNum);
            
            Assert.AreNotEqual(itemNameTie, isMenuItem.ItemName);
        }

        [TestMethod]
        public void UpdateExistingNameTest()
        {
            SetContentOneItem();

            bool ifTrue = _testMenuRepo.UpdateExistingName(itemNameTie, menuItemPizza);

            MenuItem isMenuItem = _testMenuRepo.GetByItemName(itemNamePizza);

            Assert.AreEqual(isMenuItem.ItemName, itemNamePizza);
        }

        [TestMethod]
        public void RemoveMenuItemByIdTest()
        {
            SetContentOneItem();

            bool ifTrue = _testMenuRepo.RemoveMenuItemById(MenuItemTieBurger.MenuNum);

            MenuItem itemName = _testMenuRepo.GetByItemName(itemNameTie);

            Assert.IsNull(itemName);
        }

        [TestMethod]
        public void RemoveMenuItemByNameTest()
        {
            SetContentOneItem();

            _testMenuRepo.RemoveMenuItemByName(itemNameTie);

            MenuItem isMenuItem = _testMenuRepo.GetByItemName(itemNameTie);

            Assert.IsNull(isMenuItem);
        }

        [TestMethod]
        public void GetByItemNameTest() {

            SetContentOneItem();
            
            MenuItem isMenuItem = _testMenuRepo.GetByItemName(itemNameTie);

            Assert.AreEqual(isMenuItem.ItemName, itemNameTie);
        }

        [TestMethod]
        public void GetByItemNumberTest()
        {
            SetContentOneItem();

            MenuItem isMenuItem = _testMenuRepo.GetByItemNumber(MenuItemTieBurger.MenuNum);

            Assert.AreEqual(isMenuItem.ItemName, itemNameTie);
        }

        [TestMethod]
        public void GetItemNameCountTest()
        {
            SetContentTwoItems();

            int isMenuItemCount = _testMenuRepo.GetItemNameCount();

            Assert.AreEqual(isMenuItemCount, menuItemPizza.MenuNum);
        }

        [TestMethod]
        public void SetMenuIdTest()
        {
            SetContentTwoItems();

            _testMenuRepo.SetMenuId();

            MenuItem menuItem = _testMenuRepo.GetByItemNumber(MenuItemTieBurger.MenuNum);

            Assert.AreEqual(menuItem.MenuNum, MenuItemTieBurger.MenuNum);
        }

        //Helper methods
        private void SetContentOneItem()
        {
            _testMenuRepo = new MenuRepository();
            _testMenuRepo.AddMenuItem(MenuItemTieBurger);
        }

        private void SetContentTwoItems()
        {
            _testMenuRepo = new MenuRepository();
            _testMenuRepo.AddMenuItem(MenuItemTieBurger);
            _testMenuRepo.AddMenuItem(menuItemPizza);
        }
    }
}
