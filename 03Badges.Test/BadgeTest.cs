using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _03Badges.Lib;

namespace _03Badges.Test
{
    [TestClass]
    public class BadgeTest
    {
        BadgeRepo _testRepo = new BadgeRepo();

        [TestMethod]
        public void TestCreateBadge()
        {
            Badge badge = new Badge(1, "a1", "bob");
            
            Assert.IsTrue(_testRepo.CreateBadge(badge));
        }

        [TestMethod]
        public void TestCreateBadgeOther()
        {
            Assert.IsTrue(_testRepo.CreateBadge(1, "a1", "bob"));
        }

        [TestMethod]
        public void TestGetById()
        {
            Badge badge = new Badge(1, "a1", "bob");
            _testRepo.CreateBadge(badge);
            Assert.AreSame(badge, _testRepo.GetById(badge.BadgeId));
        }

        [TestMethod]
        public void TestUpdateBadge()
        {
            Badge badge = new Badge(1, "a1", "bob");
            _testRepo.CreateBadge(badge);

            badge.BadgeName = "joe";
            _testRepo.UpdateBadgeById(badge);

            Assert.AreSame(badge.BadgeName, _testRepo.GetById(badge.BadgeId).BadgeName);
        }

        [TestMethod]
        public void TestDeleteById()
        {
            _testRepo.CreateBadge(1, "a1", "bob");

            Assert.IsTrue(_testRepo.DeleteById(1));
        }
    }
}
