using Microsoft.EntityFrameworkCore;
using MiniBank.AccountsAndTransactions.Domain.Entities;

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

    public async Task Save(Branch branch, CancellationToken cancellationToken)
    {
        BranchSet.Entry(branch).State = EntityState.Added;
        await _minibankDbContext.SaveChangesAsync(cancellationToken);
    }

}
