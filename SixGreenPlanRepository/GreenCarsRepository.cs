using System;
using System.Collections.Generic;
using System.Text;

namespace SixGreenPlanRepository
{
    public class GreenCarsRepository
    {
        private List<GreenCars> _listOfGreenCars = new List<GreenCars>();

        //Create
        public void AddGreenCarsToList(GreenCars greenCar)
        {
            int carId = _listOfGreenCars.Count;
            greenCar.Id = ++carId;
            _listOfGreenCars.Add(greenCar);
        }

        //Read
        public List<GreenCars> GetGreenCarsList()
        {
            return _listOfGreenCars;
        }

        //Update
        public bool UpdateGreenCar(int id, GreenCars newGreenCar)
        {
            GreenCars oldGreenCar = GetGreenCarById(id);

            if (newGreenCar != null && oldGreenCar != null)
            {
                oldGreenCar.CarType = newGreenCar.CarType;
                oldGreenCar.Mpg = newGreenCar.Mpg;
                oldGreenCar.TrafficTickets = newGreenCar.TrafficTickets;
                oldGreenCar.MilesDrivenYr = newGreenCar.MilesDrivenYr;
                oldGreenCar.InsuranceRate = newGreenCar.InsuranceRate;
                oldGreenCar.CarUse = newGreenCar.CarUse;
                //oldGreenCar.Id = newGreenCar.Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveGreenCarFromList(int id)
        {
            GreenCars greenCar = GetGreenCarById(id);

            int initialCount = _listOfGreenCars.Count;
            _listOfGreenCars.Remove(greenCar);

            if(initialCount > _listOfGreenCars.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helpers
        public GreenCars GetGreenCarById(int id)
        {
            foreach(GreenCars greenCar in _listOfGreenCars)
            {
                if (greenCar.Id == id)
                {
                    return greenCar;
                }
            }
            return null;
        }
    }
}
