using AuctionsApp;
using AuctionsApp.Const;
using AuctionsApp.Entities;
using AuctionsApp.Factories;
using AuctionsApp.Interfaces;
using AuctionsApp.Resources;

namespace UnitTests.CarManagementSystemTests
{
    /// <summary>
    /// Validates the business logic
    /// </summary>
    [TestFixture]
    public class CMSTests
    {
        #region Setup
        private List<Car> auctionInventory = new List<Car>();
        private List<IAuction> auctionList = new List<IAuction>();
        private CarAuctionManagementSystem mgmtSystem;
        
        [SetUp]
        public void Setup() 
        {
            PopulateAuctionInventory();
            PopulateAuctionList();
            mgmtSystem = new CarAuctionManagementSystem();
            mgmtSystem.AddCarsList(auctionInventory);
        }

        /// <summary>
        /// Populates the car inventory
        /// </summary>
        private void PopulateAuctionInventory()
        {
            var sedanFactory = new SedanFactory(2);
            var truckFactory = new TruckFactory(1000);
            var suvFactory = new SUVFactory(5);
            var hatchbackFactory = new HatchbackFactory(4);

            auctionInventory.Add(sedanFactory.CreateCar("BMW", "520", 2015, 12000));
            auctionInventory.Add(sedanFactory.CreateCar("Mercedes", "E220", 2014, 15000));
            auctionInventory.Add(sedanFactory.CreateCar("Audi", "A6", 2017, 19000));

            auctionInventory.Add(truckFactory.CreateCar("Volvo", "FH440", 2015, 32000));
            auctionInventory.Add(truckFactory.CreateCar("Iveco", "Stralis", 2014, 45000));
            auctionInventory.Add(truckFactory.CreateCar("Mercedes", "XZ", 2017, 69000));

            auctionInventory.Add(suvFactory.CreateCar("Honda", "CR-V", 2015, 16000));
            auctionInventory.Add(suvFactory.CreateCar("Porsche", "Cayenne", 2014, 17000));
            auctionInventory.Add(suvFactory.CreateCar("BMW", "X6", 2017, 19000));

            auctionInventory.Add(hatchbackFactory.CreateCar("Toyota", "Yaris", 2015, 5000));
            auctionInventory.Add(hatchbackFactory.CreateCar("Renault", "Clio", 2014, 4000));
            auctionInventory.Add(hatchbackFactory.CreateCar("Audi", "A1", 2017, 9000));
        }
        /// <summary>
        /// Populates the auction inventory based on existing cars
        /// </summary>
        private void PopulateAuctionList()
        {
            if (auctionInventory.Any())
            {
                var carToAdd = auctionInventory.First();
                auctionList.Add(new Auction(carToAdd));
            }
        }

        #endregion

        /// <summary>
        /// Validates if each car in the list returned match the column input criteria
        /// </summary>
        /// <param name="searchProperty"></param>
        /// <param name="value"></param>
        [TestCase(SearchCriteria.Manufacturer, "BMW")]
        [TestCase(SearchCriteria.Manufacturer, "Test")]
        [TestCase(SearchCriteria.Model, "A6")]
        [TestCase(SearchCriteria.Model, "Test")]
        [TestCase(SearchCriteria.Year, "2015")]
        [TestCase(SearchCriteria.Year, "2050")]
        [TestCase(SearchCriteria.Type, "1")]
        [TestCase(SearchCriteria.Type, "9999")]
        public void SearchCar_AuctionInventoryByMatchingCriteria(string searchProperty, string value)
        {
            var carsFound = mgmtSystem.SearchCars(searchProperty, value);

            Assert.IsNotNull(carsFound);

            foreach (var car in carsFound)
            {
                var propertyValue = car.GetType().GetProperty(searchProperty)?.GetValue(car, null)?.ToString();
                Assert.That(propertyValue, Is.Not.Null);
                Assert.That(value, Is.EqualTo(propertyValue));
            }
        }

        [TestCase("Test", "9999")]
        [TestCase("Id", "Fail")]
        public void SearchCar_AuctionInventoryByInvalidCriteriaReturnsError(string searchProperty, string value)
        {
            var exception = Assert.Throws<InvalidOperationException>(() => mgmtSystem.SearchCars(searchProperty, value));

            Assert.That(exception.Message, Is.EqualTo(ErrorMessage.ErrorInvalidSearchCriteria));
        }

        [TestCase("Nissan", "Sentra", 2013, 9000)]
        public void AddCar_ToAuctionInventoryWithSuccess(string manufacturer, string model, int year, decimal startingBid)
        {
            var initialInventoryCount = auctionInventory.Count;

            var sedanFactory = new SedanFactory(2);
            var car = sedanFactory.CreateCar(manufacturer, model, year, startingBid);

            mgmtSystem.AddCar(car);

            var currentInventoryCount = mgmtSystem.GetAuctionInventory()?.Count;

            Assert.That(currentInventoryCount, Is.GreaterThan(initialInventoryCount));
            Assert.That(currentInventoryCount, Is.EqualTo(initialInventoryCount + 1));
        }

        [Test]
        public void AddCar_WithDuplicatedIdReturnsError()
        {
            var car = auctionInventory.First();

            var exception = Assert.Throws<InvalidOperationException>(() => mgmtSystem.AddCar(car));

            Assert.That(exception.Message, Is.EqualTo(ErrorMessage.ErrorDuplicatedCarId));
        }
    }
}
