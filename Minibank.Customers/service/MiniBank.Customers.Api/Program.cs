using Microsoft.AspNetCore.Server.Kestrel.Core;
using MiniBank.Customers.Api.Endpoints.Grpc;
using MiniBank.CustomersSrv.Api.Endpoints;
using MiniBank.CustomersSrv.Application.DependencyInjection;
using MiniBank.Exceptions;
using MiniBank.ServiceRegistry;
using Serilog;
using System.Text.Json.Serialization.Metadata;
using Grpc.AspNetCore.Web;
using Grpc.AspNetCore;

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
    builder.Services.AddGrpc((options) =>
    {
        options.EnableDetailedErrors = true;
    });

    //builder.Services.RegisterConsulServiceDiscoveryProvider("customer-srv", "Customer Service");
    builder.Services.RegisterApplicationDependencies();

    builder.Services.AddSerilog((services, lc) =>
    {
        lc.ReadFrom.Configuration(builder.Configuration);
        lc.Enrich.FromLogContext();
    });

    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenLocalhost(5039, listenOptions =>
        {
            listenOptions.UseHttps(); // uses dev cert by default
            listenOptions.Protocols = HttpProtocols.Http2; // needed for gRPC
        });
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

  


    //app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
    app.MapGrpcService<GreeterService>();//.EnableGrpcWeb();
    
    app.AddMiniBankEndpoints();
    //app.UseMiddleware<MiniBank.Security.JwtAuthenticationMiddleware>();
    app.UseMinibankCustomExceptionHandler();
    app.Run();

}
catch (Exception ex)
{
    throw;
}

