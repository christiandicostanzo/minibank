using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using MiniBank.EntityFramework;
using System.Xml.Linq;

namespace MiniBank.AccountsAndTransactions.Infrastructure.Configurations;

internal class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("branches");
        builder.HasKey(d => d.EntityId);
        builder.ConfigureCommonFields();
        builder.Property(b => b.Name).HasColumnName("Name");
        builder.Property(b => b.Code).HasColumnName("Code");
        builder.Property(b => b.PhoneNumber).HasColumnName("PhoneNumber");
        
        builder.ComplexProperty(d => d.Address, address =>
        {
            address.Property(a => a.Street);
            address.Property(a => a.StreetNumber);
            address.Property(a => a.City);
            address.Property(a => a.Region);
            address.Property(a => a.Country);
            address.Property(a => a.PostalCode);
        });

    }
}
