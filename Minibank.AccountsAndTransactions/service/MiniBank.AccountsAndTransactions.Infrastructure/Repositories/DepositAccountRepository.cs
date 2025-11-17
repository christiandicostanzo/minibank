using Microsoft.EntityFrameworkCore;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using MiniBank.AccountsAndTransactions.Domain.Repositories;

namespace MiniBank.AccountsAndTransactions.Infrastructure.Repositories;

public class DepositAccountRepository
(
    MinibankDbContext _minibankDbContext
) : IDepositAccountRepository
{

    private DbSet<DepositAccount> DepositAccountSet
    {
        get => _minibankDbContext.Set<DepositAccount>();
    }

    public async Task<DepositAccount> GetById(Guid entityId, CancellationToken cancellationToken)
    {
        return await _minibankDbContext.Set<DepositAccount>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(d => d.EntityId == entityId, cancellationToken);
    }

    public async Task Save(DepositAccount depositAccount, CancellationToken cancellationToken)
    {
        DepositAccountSet.Entry(depositAccount).State = EntityState.Added;
        await _minibankDbContext.SaveChangesAsync(cancellationToken);
    }

}
