namespace MiniBank.AccountsAndTransactions.Domain.Entities;

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