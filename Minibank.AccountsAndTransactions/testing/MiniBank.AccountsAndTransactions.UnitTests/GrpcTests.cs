using Google.Protobuf.Reflection;
using MiniBank.AccountsAndTransactions.Application.Interfaces;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using MiniBank.AccountsAndTransactions.Infrastructure;
using MiniBank.AccountsAndTransactions.Infrastructure.Clients;
using MiniBank.AccountsAndTransactions.Infrastructure.Repositories;

namespace MiniBank.AccountsAndTransactions.UnitTests;

public class GrpcTests
{
    [Fact]
    public void Can_Call_Grpc_Service()
    { 
        CustomerGrpcClient customerGrpcClient = new CustomerGrpcClient();
        var result = customerGrpcClient.GetCustomer(Guid.NewGuid(), new CancellationToken()).Result;
        Assert.NotNull(result);
    }

}