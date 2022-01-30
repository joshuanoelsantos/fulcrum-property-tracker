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
    public class PropertyClassMap
    {
        public static void Initialize()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Property)))
            {
                BsonClassMap.RegisterClassMap<Property>(cm =>
                {
                    cm.SetIgnoreExtraElements(true);

                    cm.MapMember(c => c.Address1)
                        .SetElementName("address1");

                    cm.MapMember(c => c.Address2)
                        .SetElementName("address2");

                    cm.MapMember(c => c.MarketValue)
                        .SetElementName("marketValue");
                });
            }
        }
    }
}
