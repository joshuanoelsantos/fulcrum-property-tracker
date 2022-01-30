using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using PropertyRental.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Infrastructure
{
    public static class MongoDbClassMap
    {
        public static void Initialize()
        {
            RegisterBaseEntity();

            BidClassMap.Initialize();
            PropertyClassMap.Initialize();
        }

            private static void RegisterBaseEntity()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(BaseEntity)))
            {
                BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
                {
                    cm.MapIdMember(c => c.Id)
                        .SetIdGenerator(StringObjectIdGenerator.Instance)
                        .SetSerializer(new StringSerializer(BsonType.ObjectId));
                });
            }
        }
    }
}
