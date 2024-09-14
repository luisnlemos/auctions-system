using AuctionsApp.Const;
using AuctionsApp.Entities;
using AuctionsApp.Interfaces;
using AuctionsApp.Resources;

namespace AuctionsApp
{
    public class CarAuctionManagementSystem : IAuctionInventory, IAuctionList
    {
        private List<Car> auctionInventory = new List<Car>();
        private List<IAuction> auctionList = new List<IAuction>();

        #region Aux Methods
        
        private bool HasCarActiveAuction(Guid carId)
        {
            return auctionList.Any(a => a.AuctionedCar.Id == carId && a.IsActive);
        }

        private IAuction? GetActiveAuctionByCarId(Guid carId)
        {
            return auctionList.FirstOrDefault(a => a.AuctionedCar.Id == carId && a.IsActive);
        }

        #endregion

        #region Auction Inventory

        /// <summary>
        /// Gets the current CarInventory
        /// </summary>
        /// <returns>Car List</returns>
        public List<Car> GetAuctionInventory()
        {
            return auctionInventory;
        }

        /// <summary>
        /// Bulk addition of Cars in the Car Inventory
        /// </summary>
        /// <param name="newCars">Car List</param>
        public void AddCarsList(List<Car> newCars)
        {
            auctionInventory.AddRange(newCars);
        }

        /// <summary>
        /// Add Car in the Car Inventory
        /// </summary>
        /// <param name="newCar">Car</param>
        /// <exception cref="InvalidOperationException">Throw error for Duplicated Id in Car Inventory</exception>
        public void AddCar(Car newCar)
        {
            if (auctionInventory.Any(x => x.Id == newCar.Id))
                throw new InvalidOperationException(ErrorMessage.ErrorDuplicatedCarId);

            auctionInventory.Add(newCar);
        }

        /// <summary>
        /// Search for a defined Car property and its corresponding value in the Car Inventory
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns>Car List</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public List<Car> SearchCars(string property, string value)
        {
            switch (property)
            {
                case SearchCriteria.Type:
                    return auctionInventory.Where(x => x.Type.Equals(value)).ToList();
                case SearchCriteria.Manufacturer:
                    return auctionInventory.Where(x => x.Manufacturer.StartsWith(value)).ToList();
                case SearchCriteria.Model:
                    return auctionInventory.Where(x => x.Model.StartsWith(value)).ToList();
                case SearchCriteria.Year:
                    return auctionInventory.Where(x => x.Year.Equals(value)).ToList();
                default:
                    throw new InvalidOperationException(ErrorMessage.ErrorInvalidSearchCriteria);
            }
        }

        #endregion

        #region Auctions

        /// <summary>
        /// Gets the current AuctionInventory
        /// </summary>
        /// <returns>IAuction List</returns>
        public List<IAuction> GetAuctionList()
        {
            return auctionList;
        }

        /// <summary>
        /// Start a car auction
        /// </summary>
        /// <param name="carId">Guid</param>
        /// <returns>IAuction?</returns>
        /// <exception cref="InvalidOperationException">Throws an error if this car does not exists in the inventory or this car is already in an active auction</exception>
        public IAuction? StartAuction(Guid carId)
        {
            if (!auctionInventory.Any(x => x.Id == carId))
                throw new InvalidOperationException(ErrorMessage.ErrorCarNotFound);

            if (HasCarActiveAuction(carId))
                throw new InvalidOperationException(ErrorMessage.ErrorCarInActiveAuction);

            var car = auctionInventory.First(x => x.Id == carId);

            IAuction auction = new Auction(car);

            auction.Start();

            auctionList.Add(auction);

            return auction;
        }

        /// <summary>
        /// Close a car active auction
        /// </summary>
        /// <param name="carId">Guid</param>
        /// <returns>Auction?</returns>
        /// <exception cref="InvalidOperationException">Throws an error if not found an active auction for this car</exception>
        public IAuction? CloseAuction(Guid carId)
        {
            if (!HasCarActiveAuction(carId))
            {
                throw new InvalidOperationException(ErrorMessage.ErrorActiveAuctionForCarNotFound);
            }

            IAuction? auction = GetActiveAuctionByCarId(carId);

            auction?.Close();

            return auction;
        }

        /// <summary>
        /// Place a bid for a car active auction
        /// </summary>
        /// <param name="carId">Guid</param>
        /// <param name="bidAmount">decimal</param>
        /// <returns>IAuction?</returns>
        /// <exception cref="InvalidOperationException">Throws an error if not found an active auction for this car</exception>
        public IAuction? BidAuction(Guid carId, decimal bidAmount)
        {
            if (!HasCarActiveAuction(carId))
                throw new InvalidOperationException(ErrorMessage.ErrorActiveAuctionForCarNotFound);

            IAuction? auction = GetActiveAuctionByCarId(carId);

            auction?.Bid(bidAmount);

            return auction;
        }

        #endregion

    }
}
