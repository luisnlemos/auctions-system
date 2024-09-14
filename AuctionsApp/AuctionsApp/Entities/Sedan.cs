using AuctionsApp.Const;

namespace AuctionsApp.Entities
{
    public class Sedan : Car
    {
        public int NumberOfDoors { get; private set; }

        public Sedan(string manufacturer, string model, int year, decimal startingBid, int numberOfDoors) 
            : base(CarType.Sedan, manufacturer, model, year, startingBid)
        {
            NumberOfDoors = numberOfDoors;
        }
    }
}
