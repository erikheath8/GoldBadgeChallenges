using System;
using System.Collections.Generic;
using FourOutingsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FourOutingsTest
{
    [TestClass]
    public class OutingsTests
    {
        OutingsRepository _outingsTestRepo;

       private Outings outing = new Outings(OutingType.Bowling, 15, "4/19/2021", 0, 100);

        [TestMethod]
        public void AddOutingsToListTest()
        {
            SetTestContent();

           List<Outings> outingsList = _outingsTestRepo.GetOutingsList();

            foreach(Outings outing in outingsList)
            {
                string outingDate = outing.DateOfEvent;

                Assert.AreEqual(outingDate, outing.DateOfEvent);
            }
        }

        [TestMethod]
        public void GetOutingsListTest()
        {
            SetTestContent();

            List<Outings> outingsList = _outingsTestRepo.GetOutingsList();

            Assert.IsNotNull(outingsList);

        }

        [TestMethod]
        public void GetOutingsTotalTest()
        {
            SetTestContent();

            double? outingTotal = _outingsTestRepo.GetOutingsTotalCost();

            Assert.AreEqual(outingTotal, outing.CostOfEvent);
        }

        //helper methods
        private void SetTestContent()
        {
            _outingsTestRepo = new OutingsRepository();
            _outingsTestRepo.AddOutingsToList(outing);

        }
    }
}
