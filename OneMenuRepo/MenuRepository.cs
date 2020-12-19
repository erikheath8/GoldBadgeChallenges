using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace OneMenuRepository
{
    public class MenuRepository
    {
        private List<MenuItem> _listMenuItems = new List<MenuItem>();

        // Create
        public void AddMenuItem(MenuItem addMenuItem)
        {
            _listMenuItems.Add(addMenuItem);
        }
    
        // Read 
        public List<MenuItem> GetMenuItemList()
        {
            return _listMenuItems;
        }

        //Update methods
        public bool CopyItemByIdToIdNum(int oldItemId, int newItemId)
        {
            MenuItem oldItemIdObj = GetByItemNumber(oldItemId);
            MenuItem newItemIdObj = GetByItemNumber(newItemId);

            if (newItemIdObj == null)
            {
                MenuItem copiedOldItemObj = new MenuItem();
                AddMenuItem(copiedOldItemObj);
                copiedOldItemObj.ItemName = oldItemIdObj.ItemName;
                copiedOldItemObj.Description = oldItemIdObj.Description;
                copiedOldItemObj.Ingrediants = oldItemIdObj.Ingrediants;
                copiedOldItemObj.Price = oldItemIdObj.Price;
                copiedOldItemObj.MenuNum = newItemId;
            }
            else
            {
                newItemIdObj.ItemName = oldItemIdObj.ItemName;
                newItemIdObj.Description = oldItemIdObj.Description;
                newItemIdObj.Ingrediants = oldItemIdObj.Ingrediants;
                newItemIdObj.Price = oldItemIdObj.Price;
                newItemIdObj.MenuNum = newItemId;
            }
                oldItemIdObj.ItemName = "";
                oldItemIdObj.Description = "";
                oldItemIdObj.Ingrediants = new List<string>();
                oldItemIdObj.Price = 0.00;
                oldItemIdObj.MenuNum = oldItemIdObj.MenuNum;
           
                return true;
        }
        
        public bool UpdateExistingId(int getItemId, MenuItem newMenuIdObj)
        {
            MenuItem oldMenuIdObj = GetByItemNumber(getItemId);

            if (getItemId == oldMenuIdObj.MenuNum)
            {
                oldMenuIdObj.ItemName = newMenuIdObj.ItemName;
                oldMenuIdObj.Description = newMenuIdObj.Description;
                oldMenuIdObj.Ingrediants = newMenuIdObj.Ingrediants;
                oldMenuIdObj.Price = newMenuIdObj.Price;
                oldMenuIdObj.MenuNum = newMenuIdObj.MenuNum;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateExistingName(string origItemName, MenuItem newItemObj)
        {
            MenuItem oldItemObj = GetByItemName(origItemName);

            string oldItemBool = oldItemObj.ItemName;

            bool result = String.Equals(oldItemBool, origItemName, StringComparison.OrdinalIgnoreCase);

            if (result == true)
            {
                oldItemObj.ItemName = newItemObj.ItemName;
                oldItemObj.Description = newItemObj.Description;
                oldItemObj.Ingrediants = newItemObj.Ingrediants;
                oldItemObj.Price = newItemObj.Price;
                oldItemObj.MenuNum = newItemObj.MenuNum;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete method
        public bool RemoveMenuItemById(int getMenuNum)
        {
            MenuItem item = GetByItemNumber(getMenuNum);

            if(item == null)
            {
                return false;
            }

            int initialItemCount = GetItemNameCount();
            _listMenuItems.Remove(item);
            int postItemCount = GetItemNameCount();

            if (initialItemCount > postItemCount)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveMenuItemByName(string getItemName)
        {
            MenuItem item = GetByItemName(getItemName);

            if (item == null)
            {
                return false;
            }

            int initialItemCount = GetItemNameCount();

            _listMenuItems.Remove(item);

            int postItemCount = GetItemNameCount();

            if (initialItemCount > postItemCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helpers
        public MenuItem GetByItemName(string getItemName)
        {
            foreach (MenuItem item in _listMenuItems)
            {
                if(item.ItemName.ToLower() == getItemName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
        public MenuItem GetByItemNumber(int getItemNumber)
        {
            foreach (MenuItem item in _listMenuItems)
            {
                if (item.MenuNum == getItemNumber)
                {
                    return item;
                }
            }
            return null;
        }

        public int GetItemNameCount()
        {
            int i = 0;

            foreach (MenuItem item in _listMenuItems)
            {
                i++;
            }
            return i;
        }

        public void SetMenuId()
        {
            int i = 1;
            foreach (MenuItem item in _listMenuItems)
            {
                item.MenuNum = i;
                i++;
            }
        }

    }
}
