using MiniBank.CustomersSrv.Domain.Entities;
using MiniBank.Domain;
using MiniBank.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MiniBank.CustomersSrv.Infrastructure.Database.ClassMaps;

public class CustomerClassMap : BsonClassMapBuilder<Customer>
{
    public override void RegisterClassMap()
    {
        map.MapProperty(c => c.FirstName).SetElementName("first_name").SetIsRequired(true);
        map.MapProperty(c => c.LastName).SetElementName("last_name");
        map.MapProperty(c => c.Document).SetElementName("document");
        map.MapProperty(c => c.Address).SetElementName("address");
    }
}
