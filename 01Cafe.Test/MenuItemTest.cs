using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using _01Cafe.Lib;

namespace _01Cafe.Test
{
    [TestClass]
    public class MenuItemTest
    {
        [TestMethod]
        public void CreateMenuItemTest()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("hamburger patty");
            ingredients.Add("ketchup");
            MenuItem menuItem = new MenuItem(
                1,
                "Burger", 
                "Meat on bread",
                ingredients,
                .99);

            bool expected = true;
            //bool actual = CreateMenuItem(menuItem);

        }
    }
}
