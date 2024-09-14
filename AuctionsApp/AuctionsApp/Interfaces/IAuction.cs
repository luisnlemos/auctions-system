using AuctionsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionsApp.Interfaces
{
    public interface IAuction
    {
        public Guid AuctionId { get; }
        public Car AuctionedCar { get; }
        public bool IsActive { get; }
        public decimal HighestBid { get; }

        void Start();
        void Bid(decimal amount);
        void Close();
    }
}
