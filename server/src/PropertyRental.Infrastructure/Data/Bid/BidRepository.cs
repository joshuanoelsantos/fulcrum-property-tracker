using MongoDB.Bson;
using MongoDB.Driver;
using PropertyRental.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyRental.Infrastructure
{
    public class BidRepository : BaseRepository<Bid>, IBidRepository
    {
        private const string TableName = "Bid";

        public BidRepository(IMongoClient mongoClient, MongoDbSettings settings) :
            base(mongoClient, settings, TableName)
        {
        }

        public async Task<List<Bid>> GetByUser(string userId)
        {
            if (userId == null)
            {
                return null;
            }

            return await _collection
                .Find(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<Bid> GetHighestBid(string propertyId)
        {
            if(propertyId == null)
            {
                return null;
            }

            return await _collection
                .Find(x => x.PropertyId == propertyId)
                .SortByDescending(x => x.Amount)
                .FirstOrDefaultAsync();
        }

        public async Task<List<HighestBid>> GetHighestBids(List<string> propertyIds, string userId)
        {
            if (propertyIds == null || !propertyIds.Any())
            {
                return new List<HighestBid>();
            }
            FilterDefinition<Bid> filter = GetCompetitorBidsFilter(propertyIds, userId);

            return await _collection.Aggregate()
                .Match(filter)
                .Group(
                    y => y.PropertyId,
                    z => new HighestBid()
                    {
                        PropertyId = z.Key,
                        Amount = z.Max(a => a.Amount)
                    }
                )
                .ToListAsync();
        }

        private static FilterDefinition<Bid> GetCompetitorBidsFilter(List<string> propertyIds, string userId)
        {
            return Builders<Bid>.Filter.In(x => x.PropertyId, propertyIds) &
                Builders<Bid>.Filter.Where(x => x.UserId != userId);
        }
    }
}
