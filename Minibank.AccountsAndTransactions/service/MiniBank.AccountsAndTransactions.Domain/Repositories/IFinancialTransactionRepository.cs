using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MiniBank.AccountsAndTransactions.Domain;
using MiniBank.AccountsAndTransactions.Domain.Entities;

namespace MiniBank.AccountsAndTransactions.Domain.Repositories;

public interface IFinancialTransactionRepository
{
    public Task<FinancialTransaction> GetById(Guid entityId, CancellationToken cancellationToken);

    public Task Save(FinancialTransaction financialTransaction, CancellationToken cancellationToken);
   
}

