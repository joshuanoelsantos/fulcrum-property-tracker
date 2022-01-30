using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyRental.Core
{
    public interface IBidService
    {
        Task<BidWithProperty> GetById(string id);

        Task<List<BidWithPropertyAndHighestBid>> GetByUser(string userId);
    }
}