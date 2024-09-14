using AuctionsApp.Factories;
using AuctionsApp.Const;
using AuctionsApp.Entities;

namespace UnitTests.CarTests
{
    /// <summary>
    /// Validates each car type creation using Factory
    /// </summary>
    [TestFixture]
    public class CarTests
    {
        [TestCase(2, "Opel", "Astra", 2020, 10000)]
        [TestCase(4, "Renault", "Megane", 2017, 6520.54)]
        public void CreateCar_SedanWithCorrectProperties(int numberOfDoors, string manufacturer, string model, int year, decimal startingBid)
        {
            var sedanFactory = new SedanFactory(numberOfDoors);
            Car newCar = sedanFactory.CreateCar(manufacturer, model, year, startingBid);

            Assert.That(newCar?.Type, Is.EqualTo(CarType.Sedan));
            Assert.That(newCar?.Manufacturer, Is.EqualTo(manufacturer));
            Assert.That(newCar?.Model, Is.EqualTo(model));
            Assert.That(newCar?.Year, Is.EqualTo(year));
            Assert.That(newCar?.StartingBid, Is.EqualTo(startingBid));

            var sedan = newCar as Sedan;

            Assert.That(sedan?.NumberOfDoors, Is.EqualTo(numberOfDoors));
        }

        [TestCase(500, "Volvo", "FH440", 2020, 50000)]
        [TestCase(600, "Iveco", "Stralis", 2017, 30000)]
        public void CreateCar_TruckWithCorrectProperties(int loadCapacity, string manufacturer, string model, int year, decimal startingBid)
        {
            var sedanFactory = new TruckFactory(loadCapacity);
            Car newCar = sedanFactory.CreateCar(manufacturer, model, year, startingBid);

            Assert.That(newCar?.Type, Is.EqualTo(CarType.Truck));
            Assert.That(newCar?.Manufacturer, Is.EqualTo(manufacturer));
            Assert.That(newCar?.Model, Is.EqualTo(model));
            Assert.That(newCar?.Year, Is.EqualTo(year));
            Assert.That(newCar?.StartingBid, Is.EqualTo(startingBid));

            var truck = newCar as Truck;

            Assert.That(truck?.LoadCapacity, Is.EqualTo(loadCapacity));
        }

        [TestCase(4, "Toyota", "Yaris", 2018, 6000)]
        [TestCase(2, "Renault", "Clio", 2017, 4750.2)]
        public void CreateCar_HatchbackWithCorrectProperties(int numberOfDoors, string manufacturer, string model, int year, decimal startingBid)
        {
            var hatchbackFactory = new HatchbackFactory(numberOfDoors);
            Car newCar = hatchbackFactory.CreateCar(manufacturer, model, year, startingBid);

            Assert.That(newCar?.Type, Is.EqualTo(CarType.Hatchback));
            Assert.That(newCar?.Manufacturer, Is.EqualTo(manufacturer));
            Assert.That(newCar?.Model, Is.EqualTo(model));
            Assert.That(newCar?.Year, Is.EqualTo(year));
            Assert.That(newCar?.StartingBid, Is.EqualTo(startingBid));

            var hatchback = newCar as Hatchback;

            Assert.That(hatchback?.NumberOfDoors, Is.EqualTo(numberOfDoors));
        }

        [TestCase(2, "Honda", "CR-V", 2022, 23900)]
        [TestCase(5, "Porsche", "Cayenne", 2017, 39890)]
        public void CreateCar_SUVWithCorrectProperties(int numberOfSeats, string manufacturer, string model, int year, decimal startingBid)
        {
            var SUVFactory = new SUVFactory(numberOfSeats);
            Car newCar = SUVFactory.CreateCar(manufacturer, model, year, startingBid);

            Assert.That(newCar?.Type, Is.EqualTo(CarType.SUV));
            Assert.That(newCar?.Manufacturer, Is.EqualTo(manufacturer));
            Assert.That(newCar?.Model, Is.EqualTo(model));
            Assert.That(newCar?.Year, Is.EqualTo(year));
            Assert.That(newCar?.StartingBid, Is.EqualTo(startingBid));

            var suv = newCar as SUV;

            Assert.That(suv?.NumberOfSeats, Is.EqualTo(numberOfSeats));
        }
    }
}