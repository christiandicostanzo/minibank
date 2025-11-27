using Grpc.Core;
//using Greeter;

namespace MiniBank.Customers.Api.Endpoints.Grpc;
public class GreeterService(ILogger<GreeterService> logger)  : Greeter.GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request,
        ServerCallContext context)
    {
        logger.LogInformation("Saying hello to {Name}", request.Name);

        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}