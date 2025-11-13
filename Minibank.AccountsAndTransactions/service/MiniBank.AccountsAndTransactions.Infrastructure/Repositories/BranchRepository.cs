using Microsoft.EntityFrameworkCore;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using MiniBank.AccountsAndTransactions.Domain.Repositories;

namespace MiniBank.AccountsAndTransactions.Infrastructure.Repositories;

public class BranchRepository
(
    MinibankDbContext _minibankDbContext
) : IBranchRepository
{

    private DbSet<Branch> BranchSet
    {
        get => _minibankDbContext.Set<Branch>();
    }

    public async Task Save(Branch depositAccount, CancellationToken cancellationToken)
    {
        BranchSet.Entry(depositAccount).State = EntityState.Added;
        await _minibankDbContext.SaveChangesAsync(cancellationToken);
    }

}
