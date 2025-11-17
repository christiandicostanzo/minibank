using Microsoft.EntityFrameworkCore;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using System.Reflection;

namespace MiniBank.AccountsAndTransactions.Infrastructure;

public class MinibankDbContext : DbContext
{
    public MinibankDbContext()
    { 
        
    }

    public DbSet<Branch> Branches => Set<Branch>(); 
    public DbSet<DepositAccount> DepositAccounts => Set<DepositAccount>();
    public DbSet<FinancialTransaction> FinancialTransactions => Set<FinancialTransaction>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=admin1234;Database=accounts_transactions");
    }

    protected override void OnModelCreating(ModelBuilder mBuilder)
    {
        mBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
