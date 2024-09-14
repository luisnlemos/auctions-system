using AuctionsApp.Entities;

namespace AuctionsApp.Interfaces
{
    public interface IAuctionInventory
    {
        void StartAuction(Guid carId);
        void PlaceBid(Guid carId, string bidder, decimal bidAmount);
        void CloseAuction(Guid carId);
        List<Auction> GetAuctionInventory();
    }
}
