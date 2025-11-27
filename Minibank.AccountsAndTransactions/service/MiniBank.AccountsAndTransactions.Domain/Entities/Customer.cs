using System;
using System.Text.Json.Serialization;

namespace MiniBank.AccountsAndTransactions.Domain.Entities;

public class Customer
{
    
    public Guid EntityId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
}



