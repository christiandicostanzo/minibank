using MiniBank.Cache;
using MiniBank.CustomersSrv.Domain.Entities;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace MiniBank.CustomersSrv.Infrastructure.Cache;

public class CustomersCacheTwo
(
IRedisClientWrapper redisClientWrapper
)
: IMinibankEntityCache<Customer>
{

    const string CUSTOMER_LIST_KEY = "CUSTOMER_LIST";

    public bool SaveList(IList<Customer> customers)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.TypeInfoResolver = new DefaultJsonTypeInfoResolver();

        var customersJson = JsonSerializer.Serialize(customers, options);
        RedisKey redisKey = new(CUSTOMER_LIST_KEY);
        RedisValue redisValue = new(customersJson);
        return redisClientWrapper.Database.StringSet(redisKey, redisValue);
    }

    public List<Customer> GetList()
    {
        RedisKey redisKey = new(CUSTOMER_LIST_KEY);
        RedisValue redisValue = redisClientWrapper.Database.StringGet(redisKey);
        List<Customer> cachedCustomers = new();

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.TypeInfoResolver = new DefaultJsonTypeInfoResolver();

        if (redisValue.HasValue)
        {
            //cachedCustomers = JsonSerializer.Deserialize<List<Customer>>(redisValue, options);
        }

        return cachedCustomers;
    }

}
