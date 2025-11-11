using Microsoft.Extensions.DependencyInjection;
using MiniBank.AccountsAndTransactions.Infrastructure;
using MiniBank.AccountsAndTransactions.Infrastructure.Repositories;
using System.Reflection;

namespace MiniBank.AccountsAndTransactions.Application.DependencyInjection;

public static class ServiceExtensions
{
    public static void RegisterApplicationDependencies(this IServiceCollection services)
    {
        services.RegisterRepositories();
    }

    static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<MinibankDbContext>();
        services.AddScoped<DepositAccountRepository>();

    }

    
}
