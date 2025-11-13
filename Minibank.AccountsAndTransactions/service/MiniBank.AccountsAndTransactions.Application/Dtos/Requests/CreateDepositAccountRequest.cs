using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.AccountsAndTransactions.Application.Dtos.Requests;

public record CreateDepositAccountRequest
(
int Number,
string AccountNumber,
string AccountType,
Guid CustomerId,
string Currency,
Guid BranchId
);

