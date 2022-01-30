using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Core
{
    public record BidWithProperty(
        Bid CurrentBid,
        Property Property);
}
