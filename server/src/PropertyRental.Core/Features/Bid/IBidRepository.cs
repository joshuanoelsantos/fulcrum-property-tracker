using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyRental.Core
{
    public interface IBidRepository : IBaseRepository<Bid>
    {
        Task<List<Bid>> GetByUser(string userId);

        Task<Bid> GetHighestBid(string propertyId);

        Task<List<HighestBid>> GetHighestBids(List<string> propertyIds, string userId);
    }
}