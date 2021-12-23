using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using _01Cafe.Lib;

namespace _01Cafe.Test
{
    [TestClass]
    public class MenuItemTest
    {
        MenuItemRepo TestRepo = new MenuItemRepo();

        [TestMethod]
        public void TestCreateMenuItemMenuItem()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("hamburger patty");
            ingredients.Add("ketchup");
            MenuItem menuItem = new MenuItem(1, "Burger", "Meat on bread", ingredients, .99);

            bool expected = true;
            bool actual = TestRepo.CreateMenuItem(menuItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCreateMenuItemIndividualInput()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("hamburger patty");
            ingredients.Add("ketchup");

            bool expected = true;
            bool actual = TestRepo.CreateMenuItem(1, "Burger", "Meat on bread", ingredients, .99);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetById()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("hamburger patty");
            ingredients.Add("ketchup");
            MenuItem menuItem = new MenuItem(1, "Burger", "Meat on bread", ingredients, .99);
            TestRepo.CreateMenuItem(menuItem);

            Assert.AreEqual(menuItem, TestRepo.GetById(menuItem.MealNumber));
        }

        [TestMethod]
        public void TestGetAll()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("hamburger patty");
            ingredients.Add("ketchup");
            TestRepo.CreateMenuItem(1, "Burger", "Meat on bread", ingredients, .99);
            // Dictionary<int, MealItem> controlRepo = new Dictionary<int, MealItem>();
            // I see the problem, I made a repo for the unit test, instead of a dictionary of meal items
        }
    }
}
