using Microsoft.Extensions.Logging;
using MiniBank.AccountsAndTransactions.Application.Dtos;
using MiniBank.AccountsAndTransactions.Application.Dtos.Requests;
using MiniBank.AccountsAndTransactions.Application.Interfaces;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using MiniBank.AccountsAndTransactions.Domain.Repositories;
using MiniBank.ResultPattern;

namespace MiniBank.AccountsAndTransactions.Application.UseCases;

internal class CreateDepositAccountUseCase
(
    IDepositAccountRepository depositAccountRepository,
    ILogger<CreateDepositAccountUseCase> logger
) : ICreateDepositAccountUseCase
{
    public async Task<Result<DepositAccountDto>> CreateDepositAccount(CreateDepositAccountRequest request, CancellationToken cancellationToken)
    {
        try
        {
            DepositAccount depositAccount = new()
            {
                Number = request.Number,
                AccountNumber = request.AccountNumber,
                AccountType = AccountType.Savings,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                CustomerId = request.CustomerId,
                Currency = request.Currency,
                BranchId = request.BranchId
            };

            await depositAccountRepository.Save(depositAccount, cancellationToken);

            DepositAccountDto depositAccountDto = null;

            return Result.Success(depositAccountDto);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating a new deposit account");
            throw;
        }
    }
}

