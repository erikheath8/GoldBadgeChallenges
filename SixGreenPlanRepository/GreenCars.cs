using System;
using System.Collections.Generic;

namespace SixGreenPlanRepository
{
    public enum CarType
    {
        Gas =1,
        Hybrid,
        Electric
    }

    public enum CarUse
    {
        Personal =1,
        Work,
        Pleasure
    }

    public class GreenCars
    {
        public CarType CarType { get; set; }
        public double Mpg { get; set; }
        public int TrafficTickets { get; set; }
        public int MilesDrivenYr { get; set; }
        public double InsuranceRate { get; set; }
        public CarUse CarUse { get; set; }
        public int Id { get; set; }

        public GreenCars() { }
        public GreenCars(CarType carType, int mpg, int trafficTickets, int milesDrivenYr, double insuranceRate, CarUse carUse, int id)
        {
            CarType = carType;
            Mpg = mpg;
            TrafficTickets = trafficTickets;
            MilesDrivenYr = milesDrivenYr;
            InsuranceRate = insuranceRate;
            CarUse = carUse;
            Id = id;
        }
    }
}
