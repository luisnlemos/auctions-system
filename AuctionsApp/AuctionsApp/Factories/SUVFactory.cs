using AuctionsApp.Entities;

namespace AuctionsApp.Factories
{
    public class SUVFactory : ICarFactory
    {
        private int numberOfSeats;

        public SUVFactory(int seats)
        {
            numberOfSeats = seats;
        }

        public Car CreateCar(string manufacturer, string model, int year, decimal startingBid)
        {
            return new SUV(manufacturer, model, year, startingBid, numberOfSeats);
        }
    }
}
