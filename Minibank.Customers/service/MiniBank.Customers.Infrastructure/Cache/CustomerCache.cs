using MiniBank.Cache;
using MiniBank.CustomersSrv.Domain.Entities;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;
namespace MiniBank.CustomersSrv.Infrastructure.Cache;

public class CustomersCache
(
IRedisClientWrapper redisClientWrapper
)
: IMinibankEntityCache<Customer>
{

    public bool SaveList(string cacheKey, IList<Customer> customers)
    {
        RedisKey redisKey = new(cacheKey);
        RedisValue redisValue = new RedisValue("$") ;
        return redisClientWrapper.Database.JSON().Set(redisKey, redisValue, customers);
    }

    public List<Customer> GetList(string cacheKey)
    {
        RedisKey redisKey = new(cacheKey);
        RedisValue redisValue = RedisValue.Null;
        return redisClientWrapper.Database.JSON().Get<List<Customer>>(redisKey);
    }

    public bool Invalidate(string cacheKey)
    {
        RedisKey redisKey = new(cacheKey);
        return redisClientWrapper.Database.JSON().Del(redisKey) > 0;
    }

}
