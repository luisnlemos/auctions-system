using AuctionsApp;
using AuctionsApp.Const;
using AuctionsApp.Entities;
using AuctionsApp.Factories;

namespace UnitTests.CarManagementSystemTests
{
    [TestFixture]
    public class CMSTests
    {
        private List<Car> _carInventory = new List<Car>();
        private List<Auction> _auctionInventory = new List<Auction>();
        private CarAuctionManagementSystem _mgmtSystem;

        [SetUp]
        public void Setup() 
        {
            PopulateCarInventory();
            PopulateAuctionInventory();
            _mgmtSystem = new CarAuctionManagementSystem();
            _mgmtSystem.AddCarsList(_carInventory);
        }

        [TestCase(SearchCriteria.Manufacturer, "BMW")]
        [TestCase(SearchCriteria.Model, "A6")]
        [TestCase(SearchCriteria.Year, "2015")]
        [TestCase(SearchCriteria.Type, "1")]
        public void Search_CarInventoryByMatchingCriteria(string searchCriteria, string value)
        {
            var carsFound = _mgmtSystem.SearchCars(searchCriteria, value);

            Assert.IsNotNull(carsFound);

            foreach (var car in carsFound)
            {
                var propertyValue = car.GetType().GetProperty(searchCriteria)?.GetValue(car, null)?.ToString();
                Assert.That(propertyValue, Is.Not.Null);
                Assert.That(value, Is.EqualTo(propertyValue));
            }
        }

        private void PopulateCarInventory() 
        {
            var sedanFactory = new SedanFactory(2);
            var truckFactory = new TruckFactory(1000);
            var suvFactory = new SUVFactory(5);
            var hatchbackFactory = new HatchbackFactory(4);

            _carInventory.Add(sedanFactory.CreateCar("BMW", "520", 2015, 12000));
            _carInventory.Add(sedanFactory.CreateCar("Mercedes", "E220", 2014, 15000));
            _carInventory.Add(sedanFactory.CreateCar("Audi", "A6", 2017, 19000));

            _carInventory.Add(truckFactory.CreateCar("Volvo", "FH440", 2015, 32000));
            _carInventory.Add(truckFactory.CreateCar("Iveco", "Stralis", 2014, 45000));
            _carInventory.Add(truckFactory.CreateCar("Mercedes", "XZ", 2017, 69000));

            _carInventory.Add(suvFactory.CreateCar("Honda", "CR-V", 2015, 16000));
            _carInventory.Add(suvFactory.CreateCar("Porsche", "Cayenne", 2014, 17000));
            _carInventory.Add(suvFactory.CreateCar("BMW", "X6", 2017, 19000));

            _carInventory.Add(hatchbackFactory.CreateCar("Toyota", "Yaris", 2015, 5000));
            _carInventory.Add(hatchbackFactory.CreateCar("Renault", "Clio", 2014, 4000));
            _carInventory.Add(hatchbackFactory.CreateCar("Audi", "A1", 2017, 9000));
        }
        
        private void PopulateAuctionInventory()
        {
            if (_carInventory.Any()) 
            {
                var carToAdd = _carInventory.First();
                _auctionInventory.Add(new Auction(carToAdd));
            }
        }
    }
}
