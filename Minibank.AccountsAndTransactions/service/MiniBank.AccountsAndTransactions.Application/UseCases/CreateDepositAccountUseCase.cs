using AutoMapper;
using Consul;
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
    IMapper mapper,
    ILogger<CreateDepositAccountUseCase> logger

) : ICreateDepositAccountUseCase
{
    public async Task<Result<DepositAccountDto>> CreateDepositAccount(CreateDepositAccountRequest request, CancellationToken cancellationToken)
    {
        try
        {

            bool isAccountTypeValid = Enum.IsDefined(typeof(AccountType), request.account_type);

            if (!isAccountTypeValid)
            { 
                return Result.Failure("The account type provided is invalid.");
            }

            DepositAccount depositAccount = new()
            {
                Number = request.number,
                AccountNumber = request.account_number,
                AccountType = (AccountType)Enum.ToObject(typeof(AccountType), request.account_type),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                CustomerId = request.customer_id,
                Currency = request.currency,
                BranchId = request.branch_id
            };

            await depositAccountRepository.Save(depositAccount, cancellationToken);

            DepositAccountDto depositAccountDto = mapper.Map<DepositAccountDto>(depositAccount);

            return Result.Success(depositAccountDto);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating a new deposit account");
            throw;
        }
    }
}

