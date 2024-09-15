using AuctionsApp.Interfaces;
using AuctionsApp.Resources;

namespace AuctionsApp.Entities
{
    public class Auction : IAuction
    {
        public Guid AuctionId { get; private set; }
        public Car AuctionedCar { get; private set; }
        public bool IsActive { get; private set; }
        public decimal HighestBid { get; private set; }

        public Auction(Car auctionedCar)
        {
            AuctionedCar = auctionedCar;
            IsActive = false;
            HighestBid = auctionedCar.StartingBid;
        }

        public void Start()
        {
            IsActive = true;
        }

        public void Bid(decimal amount)
        {
            HighestBid = amount;
        }

        public void Close()
        {
            IsActive = false;
        }
    }
}
