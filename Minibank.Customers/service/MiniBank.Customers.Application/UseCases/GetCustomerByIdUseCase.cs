using MediatR;
using Microsoft.Extensions.Logging;
using MiniBank.CustomersSrv.Application.Dtos.Requests;
using MiniBank.CustomersSrv.Application.Dtos.Responses;
using MiniBank.CustomersSrv.Domain.Repositories;
using MiniBank.ResultPattern;

namespace MiniBank.CustomersSrv.Application.UseCases;

internal class GetCustomerByIdUseCase
(
    ICustomerRepository customerRepository,
    ILogger<GetCustomerByIdUseCase> logger
) : IRequestHandler<CustomerIdRequest, Result<CustomerEntitiyResponse>>
{
    public async Task<Result<CustomerEntitiyResponse>> Handle(CustomerIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await customerRepository.GetById(request.CustomerId, cancellationToken);

            if(customer == null)
            {
                return Result.Failure($"Customer with Id {request.CustomerId} not found.");
            }

            var createCustomerResponse = new CustomerEntitiyResponse()
            {
                Id = customer.EntityId,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
            
            return Result.Success(createCustomerResponse);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
