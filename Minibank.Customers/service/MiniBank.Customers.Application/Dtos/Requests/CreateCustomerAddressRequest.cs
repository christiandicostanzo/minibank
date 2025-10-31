using MediatR;
using MiniBank.Customers.Application.Dtos;
using MiniBank.CustomersSrv.Application.Dtos.Responses;
using MiniBank.ResultPattern;

namespace MiniBank.CustomersSrv.Application.Dtos.Requests;

public record CreateCustomerAddressRequest : AddressDto, IRequest<Result<AddressDto>>
{
    public Guid CustomerId { get; set; }
}
