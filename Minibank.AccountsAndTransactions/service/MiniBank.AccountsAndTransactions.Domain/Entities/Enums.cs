using MiniBank.Domain;

namespace MiniBank.AccountsAndTransactions.Domain.Entities;

public enum TransactionType
{
    Deposit,
    Withdrawal,
    Transfer,
    Payment,
    Fee,
    Interest
}

public enum TransactionStatus
{
    Pending,
    Completed,
    Failed,
    Reversed
}

public enum AccountStatus
{
    Active,
    Closed,
    Suspended,
    Frozen
}

public enum AccountType
{
    Savings,
    Checking,
    Credit,
    Loan,
    Investment
}
