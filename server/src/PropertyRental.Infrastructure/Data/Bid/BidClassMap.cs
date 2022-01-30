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
    public static class BidClassMap
    {
        public static void Initialize()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Bid)))
            {
                BsonClassMap.RegisterClassMap<Bid>(cm =>
                {
                    cm.SetIgnoreExtraElements(true);

                    cm.MapMember(c => c.PropertyId)
                        .SetElementName("propertyId")
                        .SetSerializer(new StringSerializer(BsonType.ObjectId));

                    cm.MapMember(c => c.UserId)
                        .SetElementName("userId")
                        .SetSerializer(new StringSerializer(BsonType.ObjectId));

                    cm.MapMember(c => c.Amount)
                        .SetElementName("amount");
                });
            }
        }
    }
}
