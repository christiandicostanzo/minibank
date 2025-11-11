using Microsoft.EntityFrameworkCore;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using MiniBank.AccountsAndTransactions.Domain.Repositories;

namespace MiniBank.AccountsAndTransactions.Infrastructure.Repositories;

public class DepositAccountRepository
(
    MinibankDbContext _minibankDbContext
) : IDepositAccountRepository
{

    public async Task<DepositAccount> GetById(Guid entityId, CancellationToken cancellationToken)
    {
        return await _minibankDbContext.Set<DepositAccount>().FirstOrDefaultAsync(d => d.EntityId == entityId, cancellationToken);
    }

}
