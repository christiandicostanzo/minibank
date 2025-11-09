using Consul;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using MiniBank.Cache;
using MiniBank.Customers.Application;
using MiniBank.Customers.Application.Dtos.Requests;
using MiniBank.CustomersSrv.Application.Dtos;
using MiniBank.CustomersSrv.Domain.Entities;
using MiniBank.CustomersSrv.Domain.Repositories;
using MiniBank.CustomersSrv.Infrastructure.Database;
using MiniBank.Pagination;
using MiniBank.ResultPattern;
using MiniBank.Specification;
using MongoDB.Driver;

namespace MiniBank.CustomersSrv.Application.UseCases;

internal class GetCustomersUseCase
(
    ICustomerRepository customerRepository,
    IMinibankEntityCache<Customer> customersCache,
    Specification<Customer> specification,
    ILogger<GetCustomersUseCase> logger

) : IRequestHandler<CustomerFilterRequest, Result<PagedResult<CustomerDto>>>
{

    public async Task<Result<PagedResult<CustomerDto>>>
        Handle(CustomerFilterRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var getCustomersCacheKey = string.Concat(CacheKeys.CUSTOMER_LIST + request.GetHashCode());

            var cachedCustomers = customersCache.GetList(getCustomersCacheKey);

            if (cachedCustomers != null)
            {
                return Result.Success(new PagedResult<CustomerDto>
                {
                    PageNumber = 1,
                    PageSize = cachedCustomers.Count(),
                    Items = cachedCustomers.Adapt<List<CustomerDto>>()
                });
            }

            if (request.first_name?.Length > 0)
            {
                specification = specification.And(c => c.FirstName, request.first_name);
            }

            if (request.document_id.HasValue)
            {
                specification = specification.And(c => c.Document.DocumentId, request.document_id);
            }

            var customers = await customerRepository.Get(specification, cancellationToken);

            if (customers?.Count > 0)
            {
                customersCache.SaveList(getCustomersCacheKey, customers);
            }

            var pagedResult = new PagedResult<CustomerDto>
            {
                PageNumber = 1,
                PageSize = customers.Count,
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
