using AuctionsApp.Entities;

namespace AuctionsApp.Interfaces
{
    public interface IAuctionInventory
    {
        void AddCar(Car car);
        List<Car> SearchCars(string property, string value);
        List<Car> GetAuctionInventory();
    }
}