using Microsoft.AspNetCore.Mvc;
using MiniBank.AccountsAndTransactions.Application.Dtos.Requests;
using MiniBank.AccountsAndTransactions.Application.Interfaces;
using MiniBank.AccountsAndTransactions.Domain.Entities;

namespace MiniBank.AccountsAndTransactions.Api.Endpoints;

public static class DepositAccountEndpoints
{
    public static WebApplication AddAccountsEndpoints(this WebApplication app)
    {

        var accountsApi = app.MapGroup("/deposit_accounts");

        accountsApi
            .WithDisplayName("Accocunts and Transactions Api");

        accountsApi
            .MapPost("/", CreateDepositAccount)
            .WithName("CreateDepositAccount")
            .WithSummary("Creates a new DepositAccount associated to a customer")
            .Produces<int>(201);

        accountsApi.MapPost("/{depositAccountId}", GetDepositAccountById)
            .WithName("GetDepositAccountById")
            .WithSummary("Get a DepositAccount by id")
            .Produces<DepositAccount>(200); ;

        return app;

    }

    public static async Task<IResult> GetDepositAccountById(
      [FromRoute] Guid despoitAccountId,
      IGetDepositAccountByIdUseCase getDepositAccountById,
      CancellationToken cancellation)
    {

        var result = await getDepositAccountById.GetDepositAccountById(despoitAccountId, cancellation);

        if (result.IsSuccess)
        {
            return TypedResults.Ok(result.Payload);
        }

        return TypedResults.BadRequest();
    }

    public static async Task<IResult> CreateDepositAccount(
        [FromBody] CreateDepositAccountRequest request,
        ICreateDepositAccountUseCase createDepositAccountUseCase,
        CancellationToken cancellationToken)
    {

        var result = await createDepositAccountUseCase.CreateDepositAccount(request, cancellationToken);

        if (result.IsSuccess)
        {
            return TypedResults.Ok(result.Payload);
        }

        return TypedResults.BadRequest();
    }

}
