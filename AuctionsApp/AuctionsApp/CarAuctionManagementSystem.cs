using AuctionsApp.Const;
using AuctionsApp.Entities;
using AuctionsApp.Interfaces;

namespace AuctionsApp
{
    public class CarAuctionManagementSystem : ICarInventory, IAuctionInventory
    {
        private List<Car> _carsInventory = new List<Car>();
        private List<Auction> _auctionsInventory = new List<Auction>();

        public void AddCarsList(List<Car> cars)
        {
            _carsInventory.AddRange(cars);
        }

        public void AddCar(Car car)
        {
            if (_carsInventory.Any(x => x.Id == car.Id))
                throw new InvalidOperationException("Car with this ID already exists.");

            _carsInventory.Add(car);
        }
                

        public List<Car> SearchCars(string criteria, string value)
        {
            switch (criteria)
            { 
                case SearchCriteria.Type:
                    return _carsInventory.Where(x => x.Type.Equals(value)).ToList();
                case SearchCriteria.Manufacturer:
                    return _carsInventory.Where(x => x.Manufacturer.StartsWith(value)).ToList();
                case SearchCriteria.Model:
                    return _carsInventory.Where(x => x.Model.StartsWith(value)).ToList();
                case SearchCriteria.Year:
                    return _carsInventory.Where(x => x.Year.Equals(value)).ToList();
                default:
                    throw new InvalidOperationException("Invalid search criteria");
            }
        }

        public void CloseAuction(Guid carId)
        {
            throw new NotImplementedException();
        }

        public void PlaceBid(Guid carId, string bidder, decimal bidAmount)
        {
            throw new NotImplementedException();
        }

        public void StartAuction(Guid carId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarInventory()
        {
            return _carsInventory;
        }

        public List<Auction> GetAuctionInventory()
        {
            return _auctionsInventory;
        }

        

        //public IEnumerable<Car> SearchCars(string criteria, string value)
        //{
        //    IEnumerable<Car> result;

        //    switch (criteria)
        //    { 
        //        case SearchCriteria.Type:
        //            result = _carsInventory.Where(x => x.Type.Equals(value));
        //            break;
        //        case SearchCriteria.Manufacturer:
        //            result = _carsInventory.Where(x => x.Manufacturer.Equals(value));
        //            break;
        //        case SearchCriteria.Model:
        //            result = _carsInventory.Where(x => x.Model.Equals(value));
        //            break;
        //        case SearchCriteria.Year:
        //            result = _carsInventory.Where(x => x.Year.Equals(value));
        //            break;
        //        default:
        //            throw new InvalidOperationException("Invalid search criteria");
        //    }

        //    return result;
        //}

        //public void StartAuction(Guid carId)
        //{
        //    var car = _carsInventory.FirstOrDefault(c => c.Id == carId);
        //    if (car == null)
        //    {
        //        throw new InvalidOperationException("Car not found in inventory.");
        //    }

        //    if (_auctionsInventory.Any(a => a.AuctionedCar.Id == carId && a.IsActive))
        //    {
        //        throw new InvalidOperationException("An active auction for this car already exists.");
        //    }

        //    var auction = new Auction(car);
        //    auction.StartAuction();
        //    _auctionsInventory.Add(auction);
        //}

        //public void PlaceBid(Guid carId, string bidder, decimal bidAmount)
        //{
        //    var auction = _auctionsInventory.FirstOrDefault(a => a.AuctionedCar.Id == carId && a.IsActive);
        //    if (auction == null)
        //    {
        //        throw new InvalidOperationException("No active auction found for this car.");
        //    }

        //    auction.PlaceBid(bidder, bidAmount);
        //}

        //public void CloseAuction(Guid carId)
        //{
        //    var auction = _auctionsInventory.FirstOrDefault(a => a.AuctionedCar.Id == carId && a.IsActive);
        //    if (auction == null)
        //    {
        //        throw new InvalidOperationException("No active auction found for this car.");
        //    }

        //    auction.CloseAuction();
        //}


    }
}
