namespace MiniBank.AccountsAndTransactions.Domain.Entities;

public class Address
{
    public string Street { get; set; }
    public string StreetNumber { get; set; } // Optional: separate street number
    public string City { get; set; }
    public string Region { get; set; } // Province or State
    public string Country { get; set; } // ISO 3166-1 alpha-2, e.g., "AR"
    public string PostalCode { get; set; }
}
