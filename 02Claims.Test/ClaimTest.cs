using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _02Claims.Lib;

namespace _02Claims.Test
{
    [TestClass]
    public class ClaimTest
    {
        ClaimRepo _testRepo = new ClaimRepo();

        [TestMethod]
        public void TestCreateClaim()
        {
            Claim claim = new Claim(1, "car", "was accident", 100.30, DateTime.Now, DateTime.Now.AddDays(3));
            
            bool expected = true;
            bool actual = _testRepo.CreateClaim(claim);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCreateClaimIndividual()
        {
            bool expected = true;
            bool actual = _testRepo.CreateClaim(1, "car", "was accident", 100.30, DateTime.Now, DateTime.Now.AddDays(3));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetById()
        {
            Claim claim = new Claim(1, "car", "was accident", 100.30, DateTime.Now, DateTime.Now.AddDays(3));
            _testRepo.CreateClaim(claim);
            Assert.AreSame(claim, _testRepo.GetById(claim.ClaimId));
        }

        [TestMethod]
        public void TestUpdateClaim()
        {
            Claim claim = new Claim(1, "car", "was accident", 100.30, DateTime.Now, DateTime.Now.AddDays(3));
            _testRepo.CreateClaim(claim);

            claim.ClaimAmount = 300.10;
            _testRepo.UpdateClaim(claim);

            Assert.AreEqual(claim.ClaimAmount, _testRepo.GetById(claim.ClaimId).ClaimAmount);
        }

        [TestMethod]
        public void TestDeleteById()
        {
            _testRepo.CreateClaim(1, "car", "was accident", 100.30, DateTime.Now, DateTime.Now.AddDays(3));
            Assert.IsTrue(_testRepo.DeleteById(1));
        }
    }
}
