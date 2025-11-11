using Microsoft.EntityFrameworkCore;
using MiniBank.AccountsAndTransactions.Domain.Entities;

namespace MiniBank.AccountsAndTransactions.Infrastructure.Repositories;

public class TransactionRepository
(
    MinibankDbContext _minibankDbContext
)
{

    public async Task<Transaction> GetById(Guid entityId, CancellationToken cancellationToken)
    {
        return await _minibankDbContext.Set<Transaction>().FirstOrDefaultAsync(d => d.EntityId == entityId, cancellationToken);
    }

}
