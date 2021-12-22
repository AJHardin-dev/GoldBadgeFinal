using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Cafe.Lib
{
    public class MenuItemRepo
    {
        private readonly Dictionary<int, MenuItem> _menuItems = new Dictionary<int, MenuItem>();

        public bool CreateMenuItem(MenuItem menuItem)
        {
            if (menuItem != null && !_menuItems.ContainsKey(menuItem.MealNumber))
            {
                _menuItems.Add(menuItem.MealNumber, menuItem);
                return true;
            }
            else return false;
        }

        public bool CreateMenuItem(int mealNumber, string mealName, string mealDescription, List<string> ingredients, double mealPrice)
        {
            if (!_menuItems.ContainsKey(mealNumber))
            {
                MenuItem newItem = new MenuItem(mealNumber, mealName, mealDescription, ingredients, mealPrice);
                _menuItems.Add(newItem.MealNumber, newItem);
                return true;
            }
            else return false;
        }

        public MenuItem GetById(int id)
        {
            if (_menuItems.ContainsKey(id))
                return _menuItems[id];
            else return null;
        }

        public Dictionary<int, MenuItem> GetAll()
        {
            return _menuItems;
        }

        // Update not needed according to assignment?

        public bool DeleteById(int id)
        {
            if (_menuItems.ContainsKey(id))
            {
                _menuItems.Remove(id);
                return true;
            }
            else return false;
        }
    }
}
