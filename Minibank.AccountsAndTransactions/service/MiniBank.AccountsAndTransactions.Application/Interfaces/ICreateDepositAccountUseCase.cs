using MiniBank.AccountsAndTransactions.Application.Dtos;
using MiniBank.AccountsAndTransactions.Application.Dtos.Requests;
using MiniBank.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.AccountsAndTransactions.Application.Interfaces;

public interface ICreateDepositAccountUseCase
{
    public Task<Result<DepositAccountDto>> CreateDepositAccount(CreateDepositAccountRequest request, CancellationToken cancellationToken);
}
