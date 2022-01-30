using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyRental.Core
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;
        private readonly IPropertyRepository _propertyRepository;

        public BidService(IBidRepository bidRepository, IPropertyRepository propertyRepository)
        {
            _bidRepository = bidRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<BidWithProperty> GetById(string id)
        {
            Bid currentBid = await _bidRepository.GetById(id);

            if(currentBid == null)
            {
                return null;
            }

            Property property = await _propertyRepository.GetById(currentBid.PropertyId);

            return new BidWithProperty(currentBid, property);
        }

        public async Task<List<BidWithPropertyAndHighestBid>> GetByUser(string userId)
        {
            List<Bid> userBids = await _bidRepository.GetByUser(userId);

            if(userBids == null || !userBids.Any())
            {
                return new List<BidWithPropertyAndHighestBid>();
            }

            List<string> propertyIds = userBids.Select(x => x.PropertyId).ToList();

            Task<List<Property>> getPropertyTask = _propertyRepository.GetByIds(propertyIds);
            Task<List<HighestBid>> getHighestBidTask = _bidRepository.GetHighestBids(propertyIds, userId);

            await Task.WhenAll(getPropertyTask, getHighestBidTask);

            List<Property> properties = getPropertyTask.Result ?? new List<Property>();
            List<HighestBid> highestBids = getHighestBidTask.Result ?? new List<HighestBid>();

            List<BidWithPropertyAndHighestBid> result = new();

            foreach (Bid currentBid in userBids)
            {
                Property property = properties.FirstOrDefault(x => x.Id == currentBid.PropertyId);
                HighestBid highestBid = highestBids.FirstOrDefault(x => x.PropertyId == currentBid.PropertyId);
                result.Add(new BidWithPropertyAndHighestBid(currentBid, property, highestBid));
            }

            return result;
        }
    }
}