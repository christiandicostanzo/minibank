using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBank.AccountsAndTransactions.Domain.Entities;

namespace MiniBank.AccountsAndTransactions.Infrastructure.Configurations;

internal class FinancialTransactionConfiguration : IEntityTypeConfiguration<FinancialTransaction>
{
    public void Configure(EntityTypeBuilder<FinancialTransaction> builder)
    {
        builder.ToTable("transactions");
        builder.HasKey(t => t.EntityId);
        builder.Property(t => t.DepositAccountId).HasColumnName("deposit_account_id");
        builder.Property(t => t.Type).HasColumnName("type").HasConversion<int>();
        builder.Property(t => t.Amount).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(t => t.Currency).HasColumnName("currency");
        builder.Property(t => t.Timestamp).HasColumnName("timestamp");
        builder.Property(t => t.Description).HasColumnName("description");
        builder.Property(t => t.Status).HasColumnName("status");
        builder.Property(t => t.Channel).HasColumnName("chennel");
        builder.Property(t => t.ReferenceCode).HasColumnName("reference_code");
    }

}
