using MiniBank.AccountsAndTransactions.Application.Dtos;
using MiniBank.ResultPattern;

namespace MiniBank.AccountsAndTransactions.Application.Interfaces;

public interface IGetDepositAccountByIdUseCase
{
    public Task<Result<DepositAccountDto>> GetDepositAccountById(Guid depositAccountId, CancellationToken cancellationToken);
}
