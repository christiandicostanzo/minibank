using MiniBank.Domain;

namespace MiniBank.AccountsAndTransactions.Domain.Entities;

public class Branch : AuditableEntity
{
    public string Name { get; set; } // e.g., "Downtown Branch"
    public string Code { get; set; } // Unique branch code, e.g., "BR001"
    public Address Address { get; set; }
    public string PhoneNumber { get; set; }
}
