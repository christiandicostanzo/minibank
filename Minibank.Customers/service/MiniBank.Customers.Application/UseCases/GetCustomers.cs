using Consul;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using MiniBank.Customers.Application.Dtos.Requests;
using MiniBank.CustomersSrv.Application.Dtos;
using MiniBank.CustomersSrv.Application.Dtos.Requests;
using MiniBank.CustomersSrv.Application.Dtos.Responses;
using MiniBank.CustomersSrv.Domain.Repositories;
using MiniBank.Pagination;
using MiniBank.ResultPattern;

namespace MiniBank.CustomersSrv.Application.UseCases;

internal class GetCustomersUseCase
(
    ICustomerRepository customerRepository,
    ILogger<GetCustomersUseCase> logger

) : IRequestHandler<CustomerFilterRequest, Result<PagedResult<CustomerDto>>>
{
    public async Task<Result<PagedResult<CustomerDto>>> 
        Handle(CustomerFilterRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var customers = await customerRepository.Get(request.FirstName, cancellationToken);

            var pagedResult = new PagedResult<CustomerDto>
            {
                PageNumber = 1,
                PageSize = customers.Count(),
                TotalCount = customers.Count(),
                TotalPages = 1,
                Items = customers.Adapt<List<CustomerDto>>()
            };

            return Result.Success(pagedResult);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
