using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SixGreenPlanRepository;

namespace SixGreenPlanTests
{
    [TestClass]
    public class GreenCarTests
    {
        private GreenCarsRepository _testGreenCarsRepo;

        GreenCars greenCar1 = new GreenCars(CarType.Gas, 45, 1, 15000, 1100.00, CarUse.Personal, 1);
        GreenCars greenCar2 = new GreenCars(CarType.Electric, 750, 0, 22000, 1200.95, CarUse.Pleasure, 2);

        [TestMethod]
        public void AddGreenCarsToListTest()
        {
            SetContentOneGreenCar();

            GreenCars greenCar = _testGreenCarsRepo.GetGreenCarById(greenCar1.Id);

            Assert.IsNotNull(greenCar);
        }

        [TestMethod]
        public void GetGreenCarsListTest()
        {
            SetContentOneGreenCar();

            GreenCars greenCar3 = new GreenCars(CarType.Electric, 550, 1, 17575, 1525.50, CarUse.Personal, 0);

            List<GreenCars> testGreenCarList = new List<GreenCars>();

            testGreenCarList.Add(greenCar3);
            List<GreenCars> actualGreenCarList = _testGreenCarsRepo.GetGreenCarsList();

            Assert.AreNotEqual(actualGreenCarList, testGreenCarList);
        }

        [TestMethod]
        public void UpdateGreenCarTest()
        {
            SetContentOneGreenCar();

            _testGreenCarsRepo.UpdateGreenCar(greenCar1.Id, greenCar2);

            GreenCars isGreenCar = _testGreenCarsRepo.GetGreenCarById(greenCar1.Id);

            Assert.AreEqual(isGreenCar.MilesDrivenYr, greenCar1.MilesDrivenYr);
        }

        [TestMethod]
        public void RemoveGreenCarFromListTest()
        {
            SetContentOneGreenCar();

            _testGreenCarsRepo.RemoveGreenCarFromList(greenCar1.Id);

            GreenCars testIfNullCar = _testGreenCarsRepo.GetGreenCarById(greenCar1.Id);

            Assert.IsNull(testIfNullCar);
        }

        [TestMethod]
        public void GetGreenCarByIdTest()
        {
            SetContentOneGreenCar();

            GreenCars isGreenCar = _testGreenCarsRepo.GetGreenCarById(greenCar1.Id);

            Assert.AreEqual(isGreenCar.MilesDrivenYr, greenCar1.MilesDrivenYr);
        }

        //Helper Methods
        private void SetContentOneGreenCar()
        {
            _testGreenCarsRepo = new GreenCarsRepository();
            _testGreenCarsRepo.AddGreenCarsToList(greenCar1);
        }

        private void SetContentTwoGreenCars()
        {
            _testGreenCarsRepo = new GreenCarsRepository();
            _testGreenCarsRepo.AddGreenCarsToList(greenCar1);
            _testGreenCarsRepo.AddGreenCarsToList(greenCar2);
        }

    }
}
