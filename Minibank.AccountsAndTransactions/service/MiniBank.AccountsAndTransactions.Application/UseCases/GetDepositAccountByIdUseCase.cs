using MiniBank.AccountsAndTransactions.Application.Dtos;
using MiniBank.AccountsAndTransactions.Application.Interfaces;
using MiniBank.ResultPattern;

namespace MiniBank.AccountsAndTransactions.Application.UseCases;

internal class GetDepositAccountByIdUseCase : IGetDepositAccountByIdUseCase
{
    public Task<Result<DepositAccountDto>> GetDepositAccountById(Guid depositAccountId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

