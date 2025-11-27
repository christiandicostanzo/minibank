using MiniBank.AccountsAndTransactions.Application.Interfaces;
using MiniBank.AccountsAndTransactions.Domain.Entities;

namespace Minibank.AccountsAndTransactions.Api.Endpoints;

public static class BranchEndpoints
{

    public static WebApplication AddBranchEndpoints(this WebApplication app)
    {

        var accountsApi = app.MapGroup("/branches");

        accountsApi
            .WithDisplayName("Branches Api");

        accountsApi
            .MapPost("/", CreateBranch)
            .WithName("CredateBranch")
            .WithSummary("Creates a new branch")
            .Produces<int>(201);

        accountsApi.MapGet("/{depositAccountId}", GetBranches)
            .WithName("GetBranches")
            .WithSummary("Get a paginated list of branches")
            .Produces<int>(200); ;

        return app;

    }


    public static async Task<IResult> CreateBranch(
    Guid despoitAccountId,
    IGetDepositAccountByIdUseCase getDepositAccountById,
    CancellationToken cancellation)
    {

        //var result = await getDepositAccountById.GetDepositAccountById(despoitAccountId, cancellation);

        //if (result.IsSuccess)
        //{
        //    return TypedResults.Ok(result.Payload);
        //}

        //return TypedResults.BadRequest();

        throw new NotImplementedException();
    }


    public static async Task<IResult> GetBranches(
    IGetDepositAccountByIdUseCase getDepositAccountById,
    CancellationToken cancellation)
    {

        //var result = await getDepositAccountById.GetDepositAccountById(despoitAccountId, cancellation);

        //if (result.IsSuccess)
        //{
        //    return TypedResults.Ok(result.Payload);
        //}
        //
        //return TypedResults.BadRequest();

        throw new NotImplementedException();

    }

}