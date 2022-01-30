using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Core
{
    public class Property : BaseEntity
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public decimal MarketValue { get; set; }
    }
}
