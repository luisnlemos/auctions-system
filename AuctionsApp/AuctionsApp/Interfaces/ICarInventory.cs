using AuctionsApp.Entities;

namespace AuctionsApp.Interfaces
{
    public interface ICarInventory
    {
        void AddCar(Car car);
        List<Car> SearchCars(string criteria, string value);
        List<Car> GetCarInventory();
    }
}