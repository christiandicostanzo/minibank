using Microsoft.Extensions.DependencyInjection;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using MiniBank.AccountsAndTransactions.Domain.Repositories;
using MiniBank.AccountsAndTransactions.Infrastructure;
using MiniBank.AccountsAndTransactions.Infrastructure.Repositories;

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
        services.AddScoped<IBranchRepository, BranchRepository>();
        services.AddScoped<IDepositAccountRepository,DepositAccountRepository>();
        services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();
    }
}
