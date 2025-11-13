using MiniBank.AccountsAndTransactions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.AccountsAndTransactions.Application.Dtos;

public record DepositAccountDto
(
Guid EntityId,
DateTime CreatedDate,
DateTime UpdatedDate,
int Number,
string AccountNumber,
string AccountType,
Guid CustomerI,
string Status,
DateTime? ClosedDate,
decimal Balance,
string Currency,
Guid BranchId,
DateTime LastActivityDate
);

