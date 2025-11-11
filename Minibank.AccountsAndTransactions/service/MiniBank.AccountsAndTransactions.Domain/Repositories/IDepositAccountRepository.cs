using MiniBank.AccountsAndTransactions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.AccountsAndTransactions.Domain.Repositories;

public interface IDepositAccountRepository
{
    public Task<DepositAccount> GetById(Guid entityId, CancellationToken cancellationToken);
}
