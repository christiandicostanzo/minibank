using Elastic.Serilog.Sinks;
using Elastic.Channels;
using Elastic.Transport;
using MiniBank.AccountsAndTransactions.Api.Endpoints;
using MiniBank.AccountsAndTransactions.Application.DependencyInjection;
using MiniBank.Exceptions;
using MiniBank.ServiceRegistry;
using Serilog;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;

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
        config.DocumentName = "MiniBankAPI";
        config.Title = "MiniBankAPI v1";
        config.Version = "v1";
    });

    builder.Services.AddHealthChecks();
    //builder.Services.RegisterConsulServiceDiscoveryProvider("customer-srv", "Customer Service");
    builder.Services.AddControllers();
    builder.Services.RegisterApplicationDependencies();

    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(7878);
        options.Limits.MaxRequestBodySize = 10 * 1024 * 1024; // 10 MB


        builder.WebHost.ConfigureKestrel(options =>
        {
            options.Listen(System.Net.IPAddress.Parse("127.0.0.1"), 7878); // Bind to 127.0.0.1 on port 7878
            options.Limits.MaxRequestBodySize = 10 * 1024 * 1024; // 10 MB
        });
        
    });

    builder.Services.AddSerilog((services, lc) =>
    {
        lc.ReadFrom.Configuration(builder.Configuration);
        lc.Enrich.FromLogContext();

        //lc.WriteTo.Elasticsearch(new[] { new Uri("http://localhost:9200") }, opts =>
        //{
        //    opts.DataStream = new DataStreamName("logs", "customer-service", "demo");
        //    opts.BootstrapMethod = BootstrapMethod.Failure;
        //}, transport =>
        //{
        //    transport.Authentication(new BasicAuthentication("elastic", "elastic1234"));
        //});
    });

    var app = builder.Build();

    app.MapHealthChecks("/health");

    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseOpenApi();
        app.UseSwaggerUi(config =>
        {
            config.DocumentTitle = "MiniBankAPI - Accounts and Transactions Service";
            config.Path = "/swagger";
            config.DocumentPath = "/swagger/{documentName}/swagger.json";
            config.DocExpansion = "list";
        });
    }

    app.MapControllers();
    app.AddMiniBankEndpoints();

    app.UseMinibankCustomExceptionHandler();
    app.Run("http://localhost:7878");

}
catch (Exception ex)
{
    throw;
}
