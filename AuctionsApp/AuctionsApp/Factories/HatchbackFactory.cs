using AuctionsApp.Entities;

namespace AuctionsApp.Factories
{
    public class HatchbackFactory : ICarFactory
    {
        private int numberOfDoors;

        public HatchbackFactory(int doors)
        {
            numberOfDoors = doors;
        }

        public Car CreateCar(string manufacturer, string model, int year, decimal startingBid)
        {
            return new Hatchback(manufacturer, model, year, startingBid, numberOfDoors);
        }
    }
}
