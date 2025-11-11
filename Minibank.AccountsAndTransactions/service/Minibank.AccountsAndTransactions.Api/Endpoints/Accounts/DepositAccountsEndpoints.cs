using Microsoft.AspNetCore.Http.HttpResults;
using MiniBank.ResultPattern;

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

        accountsApi.MapPost("/", GetAccountById);

        return app;

    }


    public static async Task<Results<Ok<string>, IResult>> CreateDepositAccount(
        Guid accountId,
        CancellationToken cancellation)
    {

        throw new NotImplementedException();

        //var result = await mediator.Send(request, cancellation);

       // if (result.IsSuccess)
       // {
       //     return TypedResults.Ok(result.Payload);
       // }
       //
       // return TypedResults.BadRequest();
    }

}
