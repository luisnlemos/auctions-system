using AuctionsApp.Const;

namespace AuctionsApp.Entities
{
    public class Hatchback : Car
    {
        public int NumberOfDoors { get; set; }

        public Hatchback(string manufacturer, string model, int year, decimal startingBid, int numberOfDoors)
        : base(CarType.Hatchback, manufacturer, model, year, startingBid)
        {
            NumberOfDoors = numberOfDoors;
        }
    }
}
