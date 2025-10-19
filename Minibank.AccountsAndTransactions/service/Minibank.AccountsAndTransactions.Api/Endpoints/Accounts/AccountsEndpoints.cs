using Microsoft.AspNetCore.Http.HttpResults;
using MiniBank.ResultPattern;

namespace MiniBank.AccountsAndTransactions.Api.Endpoints;

public static class CustomerEndpoints
{
    public static WebApplication AddAccountsEndpoints(this WebApplication app)
    {

        var accountsApi = app.MapGroup("/accounts");

        accountsApi
            .WithDisplayName("Accocunts and Transactions Api");

        accountsApi
            .MapGet("/{accountId}", GetAccountById)
            .WithName("GetAccountById")
            .WithSummary("Retrieve an account by Id");

        accountsApi.MapPost("/", GetAccountById);

        return app;

    }


    public static async Task<Results<Ok<string>, IResult>> GetAccountById(
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
