using Microsoft.EntityFrameworkCore;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using MiniBank.AccountsAndTransactions.Domain.Repositories;

namespace MiniBank.AccountsAndTransactions.Infrastructure.Repositories;

public class FinancialTransactionRepository 
(
    MinibankDbContext _minibankDbContext
) : IFinancialTransactionRepository
{

    private DbSet<FinancialTransaction> TransactionSet
    {
        get => _minibankDbContext.Set<FinancialTransaction>();
    }

    public async Task<FinancialTransaction> GetById(Guid entityId, CancellationToken cancellationToken)
    {
        return await _minibankDbContext.Set<FinancialTransaction>().FirstOrDefaultAsync(d => d.EntityId == entityId, cancellationToken);
    }

    public async Task Save(FinancialTransaction financialTransaction, CancellationToken cancellationToken)
    { 
        TransactionSet.Entry(financialTransaction).State = EntityState.Added;
        await _minibankDbContext.SaveChangesAsync(cancellationToken);
    }

}
