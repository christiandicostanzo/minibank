using Microsoft.Extensions.DependencyInjection;
using MiniBank.AccountsAndTransactions.Application.Interfaces;
using MiniBank.AccountsAndTransactions.Application.UseCases;
using MiniBank.AccountsAndTransactions.Domain.Repositories;
using MiniBank.AccountsAndTransactions.Infrastructure;
using MiniBank.AccountsAndTransactions.Infrastructure.Repositories;
using System.Reflection;

namespace MiniBank.AccountsAndTransactions.Application.DependencyInjection;

public static class ServiceExtensions
{
    public static void RegisterApplicationDependencies(this IServiceCollection services)
    {
        services.RegisterRepositories();
        services.RegisterUseCases();
        services.RegisterAutomapper();
    }

    static void RegisterUseCases(this IServiceCollection services)
    {
        services.AddScoped<IGetDepositAccountByIdUseCase, GetDepositAccountByIdUseCase>();
        services.AddScoped<ICreateDepositAccountUseCase, CreateDepositAccountUseCase>();
    }
    
    static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<MinibankDbContext>();
        services.AddScoped<IBranchRepository, BranchRepository>();
        services.AddScoped<IDepositAccountRepository,DepositAccountRepository>();
        services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();
    }

    static void RegisterAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper((config) =>
        {
            config.AddMaps(Assembly.GetAssembly(typeof(ServiceExtensions)));
        });
    }
}
