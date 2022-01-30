using System;

namespace PropertyRental.Core
{
    public class Bid : BaseEntity
    {
        public string PropertyId { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
