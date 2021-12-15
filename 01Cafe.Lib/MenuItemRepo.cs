using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Cafe.Lib
{
    public class MenuItemRepo
    {
        private Dictionary<int, MenuItem> _menuItems = new Dictionary<int, MenuItem>();

        public bool CreateMenuItem(MenuItem menuItem)
        {
            if (menuItem != null && !_menuItems.ContainsKey(menuItem.MealNumber))
            {
                _menuItems.Add(menuItem.MealNumber, menuItem);
                return true;
            }
            return false;
        }

        public MenuItem GetById(int id)
        {
            if (_menuItems.ContainsKey(id))
            {
                return _menuItems[id];
            }
            return null;
        }

        public Dictionary<int, MenuItem> GetAll()
        {
            return _menuItems;
        }

        // Update not needed according to assignment

        public bool DeleteById(int id)
        {
            if (_menuItems.ContainsKey(id))
            {
                _menuItems.Remove(id);
                return true;
            }
            return false;
        }
    }
}
