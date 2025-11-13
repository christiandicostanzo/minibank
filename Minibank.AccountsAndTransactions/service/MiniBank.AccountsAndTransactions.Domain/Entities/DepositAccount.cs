using MiniBank.Domain;

namespace MiniBank.AccountsAndTransactions.Domain.Entities;

public class DepositAccount : AuditableEntity
{
    public int Number { get; set; }
    public string AccountNumber { get; set; }
    public AccountType AccountType { get; set; } // Enum: Savings, Checking, Credit, etc.
    public Guid CustomerId { get; set; }
    public AccountStatus Status { get; set; } // Enum: Active, Closed, Suspended
    public DateTime? ClosedDate { get; set; }
    public decimal Balance { get; set; }
    public string Currency { get; set; } // ISO 4217 format, e.g., "USD"
    public Guid BranchId { get; set; }
    public DateTime LastActivityDate { get; set; }
}
 
