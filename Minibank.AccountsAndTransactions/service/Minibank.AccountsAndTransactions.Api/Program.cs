using MiniBank.AccountsAndTransactions.Application.DependencyInjection;
using MiniBank.Exceptions;
using Serilog;

try
{

    var builder = WebApplication.CreateSlimBuilder(args);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddOpenApiDocument(config =>
    {
        config.DocumentName = "accounts-transactions";
        config.Title = "MiniBankAPI - Accounts and Transactions";
    });

    builder.Services.AddHealthChecks();
    builder.Services.RegisterApplicationDependencies();
    builder.Services.AddSerilog((services, lc) =>
    {
        lc.ReadFrom.Configuration(builder.Configuration);
        lc.Enrich.FromLogContext();
    });

    var app = builder.Build();

    app.MapHealthChecks("/health");
    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseOpenApi();
        app.UseSwaggerUi(config =>
        {
            config.DocumentTitle = "Accounts and Transactions";
            config.Path = "/accounts-transactions/swagger";
            config.DocumentPath = "/swagger/{documentName}/swagger.json";
            config.DocExpansion = "list";
        });
    }
    
    app.AddMiniBankEndpoints();
    app.UseMinibankCustomExceptionHandler();
    
    app.Run();

}
catch (Exception ex)
{
    throw;
}
