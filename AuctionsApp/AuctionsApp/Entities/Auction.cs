namespace AuctionsApp.Entities
{
    public class Auction
    {
        public Car AuctionedCar { get; set; }
        public bool IsActive { get; private set; }
        public decimal HighestBid { get; set; }

        public Auction(Car auctionedCar)
        {
            AuctionedCar = auctionedCar;
            IsActive = false;
            HighestBid = auctionedCar.StartingBid;
        }

        public void StartAuction()
        {
            if (IsActive)
                throw new InvalidOperationException("Auction is already active.");

            IsActive = true;
        }

        public void PlaceBid(string bidder, decimal amount)
        {
            if (!IsActive)
                throw new InvalidOperationException("Auction is not active.");

            if (amount <= HighestBid)
                throw new InvalidOperationException("Bid amount must be higher than the current highest bid.");

            HighestBid = amount;
        }

        public void CloseAuction()
        {
            if (!IsActive)
                throw new InvalidOperationException("Auction is not active.");

            IsActive = false;
        }
    }
}
