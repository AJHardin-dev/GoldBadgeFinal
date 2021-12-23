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
    }
}
