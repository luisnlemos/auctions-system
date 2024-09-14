using AuctionsApp.Entities;

namespace AuctionsApp.Factories
{
    public class SedanFactory : ICarFactory
    {
        private int numberOfDoors;

        public SedanFactory(int doors)
        {
            numberOfDoors = doors;
        }

        public Car CreateCar(string manufacturer, string model, int year, decimal startingBid)
        {
            return new Sedan(manufacturer, model, year, startingBid, numberOfDoors);
        }
    }
}
