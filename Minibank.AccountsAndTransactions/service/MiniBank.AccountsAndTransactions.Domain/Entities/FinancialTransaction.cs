using MiniBank.Domain;

namespace MiniBank.AccountsAndTransactions.Domain.Entities;

public class FinancialTransaction : EntityBase
{
    public Guid DepositAccountId { get; set; } // Associated account
    public TransactionType Type { get; set; } // Enum: Deposit, Withdrawal, Transfer, Payment
    public decimal Amount { get; set; } // Transaction amount
    public string Currency { get; set; } // ISO 4217 format, e.g., "USD"
    public DateTime Timestamp { get; set; } // When the transaction occurred
    public string Description { get; set; } // Optional memo or note
    public TransactionStatus Status { get; set; } // Enum: Pending, Completed, Failed, Reversed
    public string Channel { get; set; } // e.g., "Web", "Mobile", "ATM", "API"
    public string ReferenceCode { get; set; } // External or internal reference

}
