using Consul;
using MediatR;
using Microsoft.Extensions.Logging;
using MiniBank.Customers.Application.Dtos.Requests;
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

) : IRequestHandler<CustomerFilterRequest, Result<PagedResult<CustomerEntitiyResponse>>>
{
    public async Task<Result<PagedResult<CustomerEntitiyResponse>>> 
        Handle(CustomerFilterRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var customers = await customerRepository.Get(request.FirstName, cancellationToken);

            var customersResponse = customers.Select(c => new CustomerEntitiyResponse
            {
                Id = c.EntityId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                BirthDate = c.BirthDate,
                Document = new DocumentEntityResponse
                {
                    Type = c.Document.Type,
                    DocumentId  = c.Document.DocumentId
                }
            }).ToList();

            var pagedResult = new PagedResult<CustomerEntitiyResponse>
            {
                PageNumber = 1,
                PageSize = customers.Count(),
                TotalCount = customers.Count(),
                TotalPages = 1,
                Items = customersResponse
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
