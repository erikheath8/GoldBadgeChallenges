using System;
using System.Collections.Generic;
using System.Text;

namespace OneMenuRepository
{
    public class MenuItem
    {
        public string ItemName { get; set; }
        public string Description { get; set; }
        public List<String> Ingrediants { get; set; }
        public double Price { get; set; }
        public int MenuNum { get; set; }

        public MenuItem() { }

        public MenuItem(string itemName, string descripiton, List<string> ingrediants, double price, int menuNum)
        {
            ItemName = itemName;
            Description = descripiton;
            Ingrediants = ingrediants;
            Price = price;
            MenuNum = menuNum;
        }
    }
}
