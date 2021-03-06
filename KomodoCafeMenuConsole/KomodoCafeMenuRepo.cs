using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _KomodoCafeMenuConsole
{
    public class KomodoCafeMenuRepo
    {
        protected List<MenuItem> _menuItems = new List<MenuItem>();
        //list of menu item objects to store the whole Komodo's program of food

        //Repository actions:
        //Create
        public bool AddItemToMenuList(MenuItem item)
        {
            int startingCount = _menuItems.Count();
            _menuItems.Add(item);
            bool wasAdded = (_menuItems.Count() > startingCount) ? true : false;
            return wasAdded;
        }

        //Read (one)
        public List<MenuItem> GetMenuItem(int number)
        {
            List<MenuItem> ItemByNumber = new List<MenuItem>();
            foreach (MenuItem item in _menuItems)
            {
                if (item.Number == number)
                {
                    ItemByNumber.Add(item);
                }
            }
            return ItemByNumber.ToList(); // to list is needed in case this returns two items with the same number
        }

        //Read (all by order number)
        public List<MenuItem> GetMenuItems()
        {
            List<MenuItem> ItemsByNumber = new List<MenuItem>();
            foreach (MenuItem item in _menuItems)
            {
                ItemsByNumber.Add(item);
            }
            // LINQ order by meal number
            return ItemsByNumber.OrderBy(c => c.Number).ToList();
        }

        // Delete
        public bool DeleteExistingMenuItem(MenuItem existingItem)
        {
            bool deleteResult = _menuItems.Remove(existingItem);
            return deleteResult;
        }

    }
}
