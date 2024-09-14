using AuctionsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionsApp.Const
{
    public static class SearchCriteria
    {
        public const string Type = nameof(Car.Type);
        public const string Manufacturer = nameof(Car.Manufacturer);
        public const string Model = nameof(Car.Model);
        public const string Year = nameof(Car.Year);
    }
}
