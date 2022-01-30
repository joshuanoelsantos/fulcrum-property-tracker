using MongoDB.Bson;
using MongoDB.Driver;
using PropertyRental.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(
            IMongoClient mongoClient,
            MongoDbSettings settings,
            string tableName)
        {
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);

            _collection = mongoDatabase.GetCollection<T>(tableName);
        }

        public async Task<List<T>> GetByIds(List<string> ids)
        {
            if (ids == null || !ids.Any())
            {
                return new List<T>();
            }

            return await _collection
                .Find(Builders<T>.Filter.In(x => x.Id, ids))
                .ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            if (id == null)
            {
                return null;
            }

            return await _collection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
