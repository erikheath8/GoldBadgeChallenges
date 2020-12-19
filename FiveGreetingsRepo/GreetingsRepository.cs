using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiveGreetingsRepository
{
    public class GreetingsRepository
    {
        private List<Greetings> _listOfGreetings = new List<Greetings>();

        //create 
        public void AddGreetingsToList(Greetings greeting)
        {
            _listOfGreetings.Add(greeting);
        }

        //read or get
        public List<Greetings> GetGreetings()
        {
            return _listOfGreetings;
        }

        //delete method 
        public bool RemoveGreetingByName(string firstName, string lastName)
        {
            Greetings greeting = GetGreetingsByNames(firstName, lastName);

            if (greeting == null) { return false; }

            int initialCount = _listOfGreetings.Count();
            _listOfGreetings.Remove(greeting);

            if (initialCount > _listOfGreetings.Count()) { return true; } else { return false; }

        }

        //helper method
        public Greetings GetGreetingsByNames(string firtName, string lastName)
        {
            foreach(Greetings greeting in _listOfGreetings)
            {
                if (greeting.FirstName.ToLower() == firtName.ToLower()
                    && greeting.LastName.ToLower() == lastName.ToLower())
                {
                    return greeting;

                }
            }
            return null;
        }

    }
}
