using Minibank.AccountsAndTransactions.Api.Endpoints;

public static class MiniBankEndpoints
{

    public static WebApplication AddMiniBankEndpoints(this WebApplication app)
    {
        app.AddAccountsEndpoints();

        return app;

    }

}
