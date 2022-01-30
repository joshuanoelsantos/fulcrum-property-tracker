using MongoDB.Driver;
using PropertyRental.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Infrastructure
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        private const string TableName = "Property";

        public PropertyRepository(IMongoClient mongoClient, MongoDbSettings settings) :
            base(mongoClient, settings, TableName)
        {
        }
    }
}
