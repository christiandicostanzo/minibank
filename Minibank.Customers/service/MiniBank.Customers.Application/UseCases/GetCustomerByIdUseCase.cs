using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using MiniBank.CustomersSrv.Application.Dtos;
using MiniBank.CustomersSrv.Application.Dtos.Requests;
using MiniBank.CustomersSrv.Application.Dtos.Responses;
using MiniBank.CustomersSrv.Domain.Repositories;
using MiniBank.ResultPattern;

namespace MiniBank.CustomersSrv.Application.UseCases;

internal class GetCustomerByIdUseCase
(
    ICustomerRepository customerRepository,
    ILogger<GetCustomerByIdUseCase> logger 
) : IRequestHandler<CustomerIdRequest, Result<CustomerDto>>
{
    public async Task<Result<CustomerDto>> Handle(CustomerIdRequest request, CancellationToken cancellationToken)
    {
        try
        {

            logger.LogInformation($"Trying to retrieve customet with id {request.CustomerId}");

            var customer = await customerRepository.GetById(request.CustomerId, cancellationToken);

            if (customer == null)
            {
                return Result.Failure($"Customer with Id {request.CustomerId} not found.");
            }

            logger.LogInformation($"Customer retrieved from database with Name {customer.FirstName} {customer.LastName}");
            return Result.Success(customer.Adapt<CustomerDto>());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "There was an error trying to retrieve a customer from database");
            throw;
        }
    }
}
