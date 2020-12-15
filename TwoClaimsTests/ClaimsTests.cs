using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwoClaimRespository;

namespace TwoClaimsTests
{
    [TestClass]
    public class ClaimsTests
    {
        private ClaimsRepositiory _testClaimsRepo;

        [TestMethod]
        public void AddQueueContentTest()
        {
            _testClaimsRepo = new ClaimsRepositiory();

            Claim testClaim = new Claim(1, "Car", "Car Accident on Highway 1", 40000.00, "6/05/18", "6/07/18", true);

            _testClaimsRepo.AddContentToQue(testClaim);

            Queue<Claim> queContent = _testClaimsRepo.GetQueue();

            foreach (Claim Claim in queContent)
            {
                Assert.IsNotNull(Claim);
            }
        }

        [TestMethod]
        public void CopyContentQueTest()
        {
            _testClaimsRepo = new ClaimsRepositiory();

            Queue<Claim> testQueue = new Queue<Claim>();

            Claim testClaim = new Claim(1, "Car", "Car Accident on Highway 1", 40000.00, "6/05/18", "6/07/18", true);

            testQueue.Enqueue(testClaim);

            _testClaimsRepo.CopyContentQue(testQueue);

            Queue<Claim> getTestQueues = _testClaimsRepo.GetQueue();

            foreach (Claim Claim in getTestQueues)
            {
                Assert.IsNotNull(Claim);
            }
        }

        [TestMethod]
        public void GetQueueTest()
        {
            _testClaimsRepo = new ClaimsRepositiory();

            Claim testClaim = new Claim(1, "Car", "Car Accident on Highway 1", 40000.00, "6/05/18", "6/07/18", true);

            _testClaimsRepo.AddContentToQue(testClaim);

            Queue<Claim> getTestQueues = _testClaimsRepo.GetQueue();

            foreach (Claim Claim in getTestQueues)
            {
                Assert.IsNotNull(Claim);
            }
        }

    }
}
