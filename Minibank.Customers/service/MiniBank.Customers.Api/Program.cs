using MiniBank.CustomersSrv.Api.Endpoints;
using MiniBank.CustomersSrv.Application.DependencyInjection;
using MiniBank.Exceptions;
using MiniBank.ServiceRegistry;
using Serilog;
using System.Text.Json.Serialization.Metadata;

try
{

    var builder = WebApplication.CreateSlimBuilder(args);

    builder.Services.ConfigureHttpJsonOptions(options =>
    {
        options.SerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver();
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddOpenApiDocument(config =>
    {
        config.DocumentName = "MiniBankAPI - Customers Api";
        config.Title = "MiniBankAPI - Customers Api";
    });

    builder.Services.AddHealthChecks();
    //builder.Services.RegisterConsulServiceDiscoveryProvider("customer-srv", "Customer Service");
    builder.Services.RegisterApplicationDependencies();

    builder.Services.AddSerilog((services, lc) =>
    {
        lc.ReadFrom.Configuration(builder.Configuration);
        lc.Enrich.FromLogContext();
    });

    var app = builder.Build();

    app.UsePathBase("/customers");
    app.MapHealthChecks("/healthz");

    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseOpenApi();
        app.UseSwaggerUi(config =>
        {
            config.DocumentTitle = "MiniBankAPI - Customers Service";
            config.Path = "/swagger";
            config.DocumentPath = "/swagger/{documentName}/swagger.json";
            config.DocExpansion = "list";
        });
    }

    app.AddMiniBankEndpoints();
    //app.UseMiddleware<MiniBank.Security.JwtAuthenticationMiddleware>();
    app.UseMinibankCustomExceptionHandler();
    app.Run();

}
catch (Exception ex)
{
    throw;
}

