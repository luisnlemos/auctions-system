using AuctionsApp.Entities;


namespace AuctionsApp.Factories
{
    public interface ICarFactory
    {
        Car CreateCar(string manufacturer, string model, int year, decimal startingBid);
    }
}
