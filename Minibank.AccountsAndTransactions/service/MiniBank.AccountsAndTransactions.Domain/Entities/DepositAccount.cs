using MiniBank.Domain;

namespace MiniBank.AccountsAndTransactions.Domain.Entities;

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

public class DepositAccount : AuditableEntity
{
    public int Number { get; set; }
    public string AccountNumber { get; set; }
    public AccountType AccountType { get; set; } // Enum: Savings, Checking, Credit, etc.
    public Guid CustomerId { get; set; }
    public AccountStatus Status { get; set; } // Enum: Active, Closed, Suspended
    public DateTime? ClosedAt { get; set; }
    public decimal Balance { get; set; }
    public string Currency { get; set; } // ISO 4217 format, e.g., "USD"
    public Guid BranchId { get; set; }
    public DateTime LastActivityDate { get; set; }
 
}
 
public class AuditLog
{
    public Guid AuditId { get; set; } // Unique identifier
    public DateTime Timestamp { get; set; } // When the action occurred
    public string Action { get; set; } // e.g., "AccountCreated", "TransactionPosted"
    public string EntityType { get; set; } // e.g., "Account", "Customer", "Transaction"
    public Guid EntityId { get; set; } // ID of the affected entity
    public string PerformedBy { get; set; } // Username or system identifier
    public string IPAddress { get; set; } // Source IP (optional)
    public string Changes { get; set; } // JSON diff or summary of changes
    public string Channel { get; set; } // e.g., "Web", "Mobile", "API"
    public string Remarks { get; set; } // Optional notes or context
}

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

public class Transaction : AuditableEntity
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
