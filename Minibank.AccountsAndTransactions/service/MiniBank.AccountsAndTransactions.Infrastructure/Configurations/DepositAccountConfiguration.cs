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


        builder.Property(d => d.Status).HasColumnName("status").HasConversion<int>();
        builder.Property(d => d.Number).HasColumnName("number");
        builder.Property(d => d.AccountNumber).HasColumnName("account_number");
        builder.Property(d => d.AccountType).HasColumnName("account_type").HasConversion<int>();

        builder.Property(d => d.CustomerId).HasColumnName("customer_id");
        builder.Property(d => d.ClosedDate).HasColumnName("closed_date");

        builder.Property(d => d.Balance).HasColumnName("balance");
        builder.Property(d => d.Currency).HasColumnName("currency");
        builder.Property(d => d.BranchId).HasColumnName("branch_id");
        builder.Property(d => d.LastActivityDate).HasColumnName("last_activity_date");
    }

}
