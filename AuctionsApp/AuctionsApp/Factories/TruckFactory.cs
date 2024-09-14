using AuctionsApp.Entities;

namespace AuctionsApp.Factories
{
    public class TruckFactory : ICarFactory
    {
        private int loadCapacity;

        public TruckFactory(int loadcapacity)
        {
            loadCapacity = loadcapacity;
        }

        public Car CreateCar(string manufacturer, string model, int year, decimal startingBid)
        {
            return new Truck(manufacturer, model, year, startingBid, loadCapacity);
        }
    }
}
