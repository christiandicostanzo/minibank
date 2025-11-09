using MiniBank.Specification;
using MongoDB.Driver;

namespace MiniBank.Customers.Infrastructure;

internal static class RepositoryExtensions
{
    internal static FilterDefinition<T> GetMongoDbFilter<T>(this Specification<T> specification)
    {
        MongoDbSpecification<T> unboxed = (MongoDbSpecification<T>)specification;
        return unboxed.Filter;
    }
}
