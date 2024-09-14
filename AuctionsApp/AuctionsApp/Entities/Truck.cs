using AuctionsApp.Const;

namespace AuctionsApp.Entities
{
    public class Truck : Car
    {
        public int LoadCapacity { get; private set; }

        public Truck(string manufacturer, string model, int year, decimal startingBid, int loadCapacity)
            : base(CarType.Truck, manufacturer, model, year, startingBid)
        {
            LoadCapacity = loadCapacity;
        }
    }
}
