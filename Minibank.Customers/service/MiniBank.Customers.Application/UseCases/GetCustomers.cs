using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using MiniBank.Cache;
using MiniBank.Customers.Application;
using MiniBank.Customers.Application.Dtos.Requests;
using MiniBank.CustomersSrv.Application.Dtos;
using MiniBank.CustomersSrv.Domain.Entities;
using MiniBank.CustomersSrv.Domain.Repositories;
using MiniBank.Pagination;
using MiniBank.ResultPattern;

namespace MiniBank.CustomersSrv.Application.UseCases;

internal class GetCustomersUseCase
(
    ICustomerRepository customerRepository,
    IMinibankEntityCache<Customer> customersCache,
    ILogger<GetCustomersUseCase> logger

) : IRequestHandler<CustomerFilterRequest, Result<PagedResult<CustomerDto>>>
{

    public async Task<Result<PagedResult<CustomerDto>>> 
        Handle(CustomerFilterRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var cachedCustomers = customersCache.GetList(CacheKeys.CUSTOMER_LIST);

            if (cachedCustomers != null)
            {
                //return Result.Success(cachedCustomers.Adapt());
            }

            var customers = await customerRepository.Get(request.FirstName, cancellationToken);

            if (customers != null)
            {
                customersCache.SaveList(CacheKeys.CUSTOMER_LIST, customers);
            }

            var pagedResult = new PagedResult<CustomerDto>
            {
                PageNumber = 1,
                PageSize = customers.Count(),
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
