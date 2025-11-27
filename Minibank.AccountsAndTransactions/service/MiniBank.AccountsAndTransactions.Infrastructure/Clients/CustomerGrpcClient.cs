using Grpc.Net.Client;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MiniBank.AccountsAndTransactions.Infrastructure.Clients;
//https://learn.microsoft.com/en-us/aspnet/core/grpc/client?view=aspnetcore-10.0
public class CustomerGrpcClient
{

    public CustomerGrpcClient()
    {

    }

    public async Task<Customer> GetCustomer(Guid customerId, CancellationToken cancellationToken)
    {

        using var channel = GrpcChannel.ForAddress("https://localhost:5039");
        var client = new Greeter.GreeterClient(channel);
        var reply = await client.SayHelloAsync(
            new HelloRequest { Name = "Christian DC" });

        await Task.Delay(50, cancellationToken);
        return new Customer
        {
            EntityId = customerId,
            FirstName = "John",
            LastName = "Doe"
        };

    }


}
