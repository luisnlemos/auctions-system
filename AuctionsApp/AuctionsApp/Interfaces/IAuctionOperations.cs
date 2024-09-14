using AuctionsApp.Entities;

namespace AuctionsApp.Interfaces
{
    public interface IAuctionOperations
    {
        IAuction? StartAuction(Guid carId);
        IAuction? BidAuction(Guid carId, decimal bidAmount);
        IAuction? CloseAuction(Guid auctionId);
        List<IAuction> GetAuctionList();
        void AddCar(Car car);
        List<Car> SearchCars(string property, string value);
        List<Car> GetAuctionInventory();
    }
}
