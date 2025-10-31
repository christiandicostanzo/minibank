using MediatR;
using MiniBank.CustomersSrv.Application.Dtos.Responses;
using MiniBank.ResultPattern;
using System.Text.Json.Serialization;

namespace MiniBank.CustomersSrv.Application.Dtos.Requests;

public record CreateCustomerRequest : CustomerDto, IRequest<Result<CustomerEntitiyResponse>>
{

}
