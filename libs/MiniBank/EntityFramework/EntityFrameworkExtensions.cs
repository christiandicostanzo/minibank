using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBank.Domain;

namespace MiniBank.EntityFramework;

public static class EntityFrameworkExtensions
{
    public static void ConfigureCommonFields<T>(this EntityTypeBuilder<T> builder) where T : AuditableEntity
    {
        builder.Property(d => d.EntityId).HasColumnName("EntityId");
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
    }
}
