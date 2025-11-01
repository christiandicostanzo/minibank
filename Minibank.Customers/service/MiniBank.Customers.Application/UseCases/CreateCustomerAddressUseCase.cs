using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using MiniBank;
using MiniBank.Customers.Application.Dtos;
using MiniBank.CustomersSrv.Application.Dtos.Requests;
using MiniBank.CustomersSrv.Application.Dtos.Responses;
using MiniBank.CustomersSrv.Application.Dtos.Validators;
using MiniBank.CustomersSrv.Domain.Entities;
using MiniBank.CustomersSrv.Domain.Repositories;
using MiniBank.ResultPattern;
using MiniBank.ServiceRegistry;
using MongoDB.Driver;


namespace MiniBank.CustomersSrv.Application.UseCases;

public class CreateCustomerAddressUseCase
(
    ICustomerRepository customerRepository,
    IValidator<CreateCustomerAddressRequest> CreateCustomerAddressRequestValidator,
    ILogger<CreateCustomerAddressUseCase> logger
)
: IRequestHandler<CreateCustomerAddressRequest, Result<AddressDto>>
{

    public async Task<Result<AddressDto>> Handle(CreateCustomerAddressRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validation = CreateCustomerAddressRequestValidator.Validate(request);

            if (!validation.IsValid)
            {
                return Result.Failure(validation.Errors.First().ErrorMessage);
            }

            var customer = await customerRepository.GetById(request.CustomerId, cancellationToken);

            if (customer == null)
            {
                Result.Failure("Customer not found");
            }

            customer.Address = new Address()
            {
                State = request.State,
                ZipCode = request.ZipCode,
                StreetName = request.StreetName,
                City= request.City, 
                StreetNumber = request.StreetNumber
            };

            customer.UpdatedDate = DateTime.UtcNow;

            var updateResult = await customerRepository.Update(customer, cancellationToken);

            return Result.Success<AddressDto>(customer.Address.Adapt<AddressDto>());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }

}
