using MiniBank.AccountsAndTransactions.Domain.Entities;

public interface IBranchRepository
{
    public Task Save(Branch branch, CancellationToken cancellationToken);
}
