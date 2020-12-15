using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwoClaimTest
{
    [TestClass]
    public class ClaimsTests
    {
        private Queue<Claim> _testClaimRepo;

       [TestMethod]
        public void AddContentToQueTest()
        {

            _testClaimRepo = new Queue<Claim>();
                        
            Claim testOne = new Claim(1, "Car", "Accident on Highway.", 40000.00, "6/06/18", "6/10/18", true);

            _testClaimRepo.Enqueue(testOne);

            //_testClaimRepo;
        }
    }
}
