using Microsoft.EntityFrameworkCore;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using System.Reflection;

namespace MiniBank.AccountsAndTransactions.Infrastructure;

public class MinibankDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        optionsBuilder.UseNpgsql((options) =>
        {
            options.ConfigureDataSource((dsBuilder) =>
            {
                dsBuilder.ConnectionStringBuilder.Username = "admin";
                dsBuilder.ConnectionStringBuilder.Password = "admin";
                dsBuilder.ConnectionStringBuilder.Host = "localhost";
                dsBuilder.ConnectionStringBuilder.Port = 5432;
            });
        });
    }

    protected override void OnModelCreating(ModelBuilder mBuilder)
    {
        mBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
