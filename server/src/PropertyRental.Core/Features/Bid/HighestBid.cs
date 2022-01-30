using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Core
{
    public record HighestBid
    {
        public string PropertyId { get; init; }
        public decimal Amount { get; init; }
    }
}
