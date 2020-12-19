using System;

namespace FourOutingsRepository
{
    public enum OutingType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }

    public class Outings
    {
        public OutingType OutingType { get; set; }
        public int NumOfPeople { get; set; }
        public string DateOfEvent { get; set; }
        public Double CostOfEvent { get { return CostPerPerson * NumOfPeople; } }
        public Double CostPerPerson { get; set; }

        public Outings() { }

        public Outings(OutingType outingType, int numOfPeople, string dateOfEvent, double costOfEvent, double costPerPerson) {

            OutingType = outingType;
            NumOfPeople = numOfPeople;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
        }
    }
}
