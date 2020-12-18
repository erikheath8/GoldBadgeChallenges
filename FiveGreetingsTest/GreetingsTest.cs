using System;
using System.Collections.Generic;
using FiveGreetingsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiveGreetingsTest
{
    [TestClass]
    public class GreetingsTest
    {
        GreetingsRepository _greetingsTestRepo;
        private Greetings person2 = new Greetings("Jack", "Ryan", GreetingType.past, "It's been a long time since we've heard from you, we want you back.");

        [TestMethod]
        public void AddGreetingsToListTest()
        {
            SetTestContent();

            Greetings greeting = _greetingsTestRepo.GetGreetingsByNames(person2.FirstName, person2.LastName);

            Assert.AreEqual(greeting.LastName, person2.LastName);
        }

        [TestMethod]
        public void GetGreetingsTest()
        {
            SetTestContent();

            List<Greetings> greetings = _greetingsTestRepo.GetGreetings();

            int index = greetings.IndexOf(person2);
            Greetings greeting = greetings[index];
                        
            Assert.AreEqual(greeting.LastName, person2.LastName);
        }

        [TestMethod]
        public void GetGreetingsByNameTest()
        {
            SetTestContent();

            Greetings greeting = _greetingsTestRepo.GetGreetingsByNames(person2.FirstName, person2.LastName);

            Assert.AreEqual(greeting.LastName, person2.LastName);
        }

        [TestMethod]
        public void RemoveGreetingByNameTest()
        {
            SetTestContent();
            _greetingsTestRepo.RemoveGreetingByName(person2.FirstName, person2.LastName);

            Greetings greeting = _greetingsTestRepo.GetGreetingsByNames(person2.LastName, person2.FirstName);

            Assert.IsNull(greeting);
        }

        //helper methods
        private void SetTestContent()
        {
            _greetingsTestRepo = new GreetingsRepository();
            _greetingsTestRepo.AddGreetingsToList(person2);
        }

    }
}
