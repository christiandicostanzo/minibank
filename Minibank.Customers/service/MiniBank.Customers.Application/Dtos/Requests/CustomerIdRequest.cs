using MediatR;
using MiniBank.CustomersSrv.Application.Dtos.Responses;
using MiniBank.ResultPattern;
using System.Text.Json.Serialization;

namespace MiniBank.CustomersSrv.Application.Dtos.Requests;

public record CustomerIdRequest : IRequest<Result<CustomerDto>>
{
    [JsonPropertyName("customer_id")]
    public Guid CustomerId { get; set; }
}