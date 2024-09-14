using AuctionsApp.Entities;

namespace AuctionsApp.Interfaces
{
    public interface IAuctionList
    {
        IAuction? StartAuction(Guid carId);
        IAuction? BidAuction(Guid carId, decimal bidAmount);
        IAuction? CloseAuction(Guid auctionId);
        List<IAuction> GetAuctionList();
    }
}
