using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Core
{
    public record BidWithPropertyAndHighestBid
    {
        public BidWithPropertyAndHighestBid(Bid currentBid, Property property, HighestBid highestBid)
        {
            CurrentBid = currentBid;
            Property = property;
            HighestBid = highestBid;
        }

        public Bid CurrentBid { get; init; }
        public Property Property { get; init; }
        public HighestBid HighestBid { get; init; }

        public bool IsWinning => CurrentBid.Amount >= (HighestBid?.Amount ?? 0);
    }
}
