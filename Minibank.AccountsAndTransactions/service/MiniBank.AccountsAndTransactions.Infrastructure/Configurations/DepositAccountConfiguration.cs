using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using MiniBank.EntityFramework;

namespace MiniBank.AccountsAndTransactions.Infrastructure.Configurations;

public class DepositAccountConfiguration : IEntityTypeConfiguration<DepositAccount>
{
    public void Configure(EntityTypeBuilder<DepositAccount> builder)
    {
        builder.ToTable("deposit_accounts");
        builder.HasKey(d => d.EntityId);
        builder.Property(d => d.UpdatedDate).HasColumnName("updated_date");
        builder.ConfigureCommonFields();

        builder.Property(d => d.AccountType).HasConversion<int>();
        builder.Property(d => d.Status).HasConversion<int>();
    }
}
