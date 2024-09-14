using AuctionsApp.Const;

namespace AuctionsApp.Entities
{
    public class SUV : Car
    {
        public int NumberOfSeats { get; set; }

        public SUV(string manufacturer, string model, int year, decimal startingBid, int numberOfSeats)
            : base(CarType.SUV, manufacturer, model, year, startingBid)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}
