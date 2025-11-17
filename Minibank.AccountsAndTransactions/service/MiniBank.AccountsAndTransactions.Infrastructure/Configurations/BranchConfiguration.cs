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
        builder.ConfigureCommonFields();
        builder.HasKey(d => d.EntityId);
        builder.Property(b => b.Name).HasColumnName("name");
        builder.Property(b => b.Code).HasColumnName("code");
        builder.Property(b => b.PhoneNumber).HasColumnName("phone_number");
        
        builder.ComplexProperty(d => d.Address, address =>
        {
            address.Property(a => a.Street).HasColumnName("street");
            address.Property(a => a.StreetNumber).HasColumnName("street_number");
            address.Property(a => a.City).HasColumnName("city");
            address.Property(a => a.Region).HasColumnName("region");
            address.Property(a => a.Country).HasColumnName("country");
            address.Property(a => a.PostalCode).HasColumnName("postal_code");
        });

    }
}
