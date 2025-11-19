using MiniBank.AccountsAndTransactions.Application.Dtos;
using MiniBank.AccountsAndTransactions.Application.Dtos.Requests;
using MiniBank.Pagination;
using MiniBank.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.AccountsAndTransactions.Application.Interfaces;

public interface ICreateBranchUseCase
{
    public Task<Result<BranchDto>> CreateBranch(CreateBranchRequest request, CancellationToken cancellationToken);
}

public interface IGetBranchesUseCase
{
    public Task<Result<PagedResult<BranchDto>>> GetBranches(string name, CancellationToken cancellationToken);
}

public interface IGetBranchById
{
    public Task<Result<BranchDto>> GetBranches(Guid branchId, CancellationToken cancellationToken);
}
