using MongoDB.Bson.Serialization;
using System.Net;

namespace MiniBank.MongoDB;

//https://www.mongodb.com/docs/drivers/csharp/current/serialization/class-mapping/
public abstract class BsonClassMapBuilder<T>
{
    protected BsonClassMap<T> map = new BsonClassMap<T>();

    public BsonClassMap<T> BsonMap 
    { 
        get => map;
    }
    
    public abstract void RegisterClassMap();
}
