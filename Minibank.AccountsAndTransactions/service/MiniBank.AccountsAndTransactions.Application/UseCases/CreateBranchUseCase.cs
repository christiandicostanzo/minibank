using MiniBank.AccountsAndTransactions.Application.Dtos;
using MiniBank.AccountsAndTransactions.Application.Dtos.Requests;
using MiniBank.AccountsAndTransactions.Application.Interfaces;
using MiniBank.Pagination;
using MiniBank.ResultPattern;

namespace MiniBank.AccountsAndTransactions.Application.UseCases;

internal class CreateBranchUseCase : ICreateBranchUseCase
{
    public Task<Result<BranchDto>> CreateBranch(CreateBranchRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

}


internal class GetBranchesUseCase : IGetBranchesUseCase
{
    public Task<Result<PagedResult<BranchDto>>> GetBranches(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}


public interface IGetBranchById
{
    public Task<Result<BranchDto>> GetBranches(Guid branchId, CancellationToken cancellationToken);
}


