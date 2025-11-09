using MiniBank.CustomersSrv.Domain.Entities;

namespace MiniBank.CustomersSrv.Domain.Repositories;

public interface ICustomerRepository
{
    Task Save(Customer customer, CancellationToken cancellationToken);
    Task<bool> Update(Customer customer, CancellationToken cancellationToken);
    Task<Customer> GetById(Guid customerId, CancellationToken cancellationToken);
    Task<Customer> GetByDocument(Document document, CancellationToken cancellationToken);
    Task<List<Customer>> Get(string name, CancellationToken cancellationToken);
}
