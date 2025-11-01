using MiniBank.Customers.Application.Dtos;
using System.Text.Json.Serialization;

namespace MiniBank.CustomersSrv.Application.Dtos;

public record CustomerDto 
{

    [JsonPropertyName("id")]
    public Guid EntityId { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("birth_date")]
    public DateTime BirthDate { get; set; }

    [JsonPropertyName("document")]
    public DocumentDto Document { get; set; }

    [JsonPropertyName("address")]
    public AddressDto Address { get; set; }
}
