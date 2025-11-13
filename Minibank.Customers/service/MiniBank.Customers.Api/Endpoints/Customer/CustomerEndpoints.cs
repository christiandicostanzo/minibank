using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Customers.Application.Dtos;
using MiniBank.Customers.Application.Dtos.Requests;
using MiniBank.CustomersSrv.Application.Dtos;
using MiniBank.CustomersSrv.Application.Dtos.Requests;
using MiniBank.CustomersSrv.Application.Dtos.Responses;
using MiniBank.ResultPattern;

namespace MiniBank.CustomersSrv.Api.Endpoints.Customer;

public static class CustomerEndpoints
{
    public static WebApplication AddCustomerEndpoints(this WebApplication app)
    {

        var customerApi = app.MapGroup("/customers");

        customerApi
            .WithDisplayName("Minibank - Customer Api");

        customerApi
            .MapGet("/{customerId}", GetCustomerById)
            .WithName("GetCustomerById")
            .WithSummary("Es el endpoint que permite obtener los customer por ID")
            .Produces<CustomerDto>(200);

        customerApi
            .MapGet("/", GetCustomers)
            .WithName("GetCustomers")
            .WithSummary("Allows search customers using filters")
            .Produces<List<CustomerDto>>(200);

        customerApi.MapPost("/", CreateCustomer)
            .WithName("Create Customers ")
            .WithSummary("Allows to create a new customer")
            .Produces<CustomerDto>(201);

        customerApi.MapPost("/{customerId}", UpdateCustomer)
            .WithName("Update Customer")
            .WithSummary("Allows to update only customer's fields")
            .Produces<CustomerDto>(200);

        customerApi.MapPost("/{customerId}/addresses", CreateCustomerAddress)
            .WithName("Create Customer Address")
            .WithSummary("Allows to add or update a customer's address")
            .Produces<AddressDto>(201);

        return app;

    }


    public static async Task<Results<Ok<CustomerEntitiyResponse>, IResult>> CreateCustomer(
        CreateCustomerRequest request,
        IMediator mediator,
        CancellationToken cancellation)
    {

        var result = await mediator.Send(request, cancellation);

        if (result.IsError)
        {
            return TypedResults.BadRequest(result.Error);
        }

        return TypedResults.Ok(result.Payload);
    }

    public static async Task<IResult> CreateCustomerAddress(
        [FromRoute] Guid customerId,
        CreateCustomerAddressRequest createCustomerRequest,
        IMediator mediator,
        CancellationToken cancellationToken)
    {

        createCustomerRequest.CustomerId = customerId;

        var result = await mediator.Send(createCustomerRequest, cancellationToken);

        if (result.IsError)
        {
            return TypedResults.BadRequest(result.Error);
        }

        return TypedResults.Ok(result.Payload);
    }

    public static async Task<IResult> UpdateCustomer(
        [FromRoute] Guid customerId,
        UpdateCustomerRequest updateCustomerRequest,
        IMediator mediator,
        CancellationToken cancellation)
    {

        updateCustomerRequest.Id = customerId;

        var result = await mediator.Send(updateCustomerRequest, cancellation);

        if (result.IsError)
        {
            return TypedResults.NotFound(result.Error);
        }

        return TypedResults.Ok(result.Payload);
    }


    public static async Task<IResult> GetCustomerById(
       Guid customerId,
       IMediator mediator,
       CancellationToken cancellation)
    {

        var customerIdRequest = new CustomerIdRequest()
        {
            CustomerId = customerId
        };

        var result = await mediator.Send(customerIdRequest, cancellation);

        if (result.IsError)
        {
            return TypedResults.NotFound(result.Error);
        }

        return TypedResults.Ok(result.Payload);
    }

    public static async Task<IResult> GetCustomers(
      [AsParameters] CustomerFilterRequest customerFilterRequest,
      IMediator mediator,
      CancellationToken cancellation)
    {
        var result = await mediator.Send(customerFilterRequest, cancellation);

        if (result.IsError)
        {
            return TypedResults.NotFound(result.Error);
        }

        return TypedResults.Ok(result.Payload);
    }

}
