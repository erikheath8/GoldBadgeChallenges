using System;

namespace FiveGreetingsRepository
{
    public enum GreetingType
    {
        current = 1,
        past,
        potential
    }
    public class Greetings
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GreetingType Greeting { get; set; }
        public string EmailString
        {
            get
            {
                if (Greeting == GreetingType.current)
                {
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                }
                else if (Greeting == GreetingType.past)
                {
                    return "It's been a long time since we've heard from you, we want you back.";
                }
                else if (Greeting == GreetingType.potential)
                {
                    return "We currently have the lowest rates on Helicopter Insurance!";
                }
                return null;
            }
        }

        public Greetings() { }

        public Greetings(string firstName, string lastName, GreetingType greetingType, string emailString)
        {
            FirstName = firstName;
            LastName = lastName;
            Greeting = greetingType;
        }

    }
}
