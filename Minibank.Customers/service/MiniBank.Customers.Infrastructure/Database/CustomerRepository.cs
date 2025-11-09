using MiniBank.CustomersSrv.Domain.Entities;
using MiniBank.CustomersSrv.Domain.Repositories;
using MiniBank.Exceptions;
using MiniBank.MongoDB;
using MongoDB.Driver;

namespace MiniBank.CustomersSrv.Infrastructure.Database;

public class CustomerRepository
(
   IMongoDbDatabaseContext<Customer> customerDbContext
)
: ICustomerRepository
{

    public async Task<Customer> GetById(Guid customerId, CancellationToken cancellationToken)
    {
        var filter = Builders<Customer>.Filter.Eq(c => c.EntityId, customerId);
        return await customerDbContext.Collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Customer> GetByDocument(Document document, CancellationToken cancellationToken)
    {
        var documentIdFilter = Builders<Customer>.Filter.Eq(C => C.Document.DocumentId, document.DocumentId);
        var documentType = Builders<Customer>.Filter.Eq(C => C.Document.Type, document.Type);
        var filter = Builders<Customer>.Filter.And(documentIdFilter, documentType);

        return await customerDbContext.Collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<Customer>> Get(string name, CancellationToken cancellationToken)
    {
        var filter = Builders<Customer>.Filter.StringIn(c => c.FirstName, name);
        return await customerDbContext.Collection.Find(filter).ToListAsync();
    }

    public async Task Save(Customer customer, CancellationToken cancellationToken)
    {
        await customerDbContext.Collection.InsertOneAsync(customer, null, cancellationToken);
    }

    public async Task<bool> Update(Customer customer, CancellationToken cancellationToken)
    {
        var replacementResult = await customerDbContext.Collection.ReplaceOneAsync<Customer>((c) =>
                             c.EntityId == customer.EntityId, customer, cancellationToken: cancellationToken);

        return replacementResult.ModifiedCount > 0;
    }

}