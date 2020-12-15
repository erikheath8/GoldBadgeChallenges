using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeBadgeRepository;

namespace ThreeBadgeTests
{
    [TestClass]
    public class BadgeTests
    {
        BadgeRepository _testBadgeRepo;

        [TestMethod]
        public void AddContentTest()
        {
            SetContent();

            Dictionary<int, Badge> _testBadges = _testBadgeRepo.GetDictionary();

            foreach (KeyValuePair<int, Badge> keyValuePair in _testBadges)
            {
                Assert.IsNotNull(keyValuePair.Key);
                //Below Test Shud Fail
                //Assert.IsNull(keyValuePair.Key);
            }
        }

        [TestMethod]
        public void GetDictionaryTest()
        {
            SetContent();

            Dictionary<int, Badge> _testBadges = _testBadgeRepo.GetDictionary();

            foreach (KeyValuePair<int, Badge> keyValuePair in _testBadges)
            {
                Assert.IsNotNull(keyValuePair.Key);
                //Below Test Shud Fail
                //Assert.IsNull(keyValuePair.Key);
            }
        }

        [TestMethod]
        public void RemoveSingleDoorTest()
        {
            SetContent();

            _testBadgeRepo.RemoveSingleDoor(1, "A5");

            bool isFalse = CheckForExist("A5");

            Assert.IsFalse(isFalse);
        }

        [TestMethod]
        public void RemoveAllDoorsTest()
        {
            SetContent();

            _testBadgeRepo.RemoveAllDoors(1);

            bool isFalse = CheckForExist("A5");

            Assert.IsFalse(isFalse);
        }

        [TestMethod]
        public void RemoveAllTest() {

            SetContent();

            _testBadgeRepo.RemoveAll(1);

            bool isFalse = CheckForExist("A5");

            Assert.IsFalse(isFalse);

        }

        [TestMethod]
        public void AddDoorTest()
        {
            SetContent();

            _testBadgeRepo.AddDoor(1, "A9");

            bool isTrue = CheckForExist("A9");

            Assert.IsTrue(isTrue);
        }

        //Helper Functions

        public void SetContent()
        {
            _testBadgeRepo = new BadgeRepository();

            var badge1 = new Badge(1, new List<string> { "A5", "A6", "A7" });

            _testBadgeRepo.AddContent(badge1.BadgeID, badge1);
        }

        public bool CheckForExist(string getDoor)
        {
            bool isTrue = false;

            Dictionary<int, Badge> _testBadges = _testBadgeRepo.GetDictionary();

            foreach (KeyValuePair<int, Badge> _keyValuePairs in _testBadges)
            {
                int badgeId = _keyValuePairs.Value.BadgeID;
                List<string> doors = _keyValuePairs.Value.DoorNames;

                foreach (string door in doors)
                {
                    if (doors.Contains(getDoor))
                    {
                        isTrue = true;
                    }
                }
            }
            return isTrue;
        }
    }
}
