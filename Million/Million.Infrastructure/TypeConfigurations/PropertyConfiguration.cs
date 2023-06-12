using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Million.Core.Entities;

namespace Million.Infrastructure.TypeConfigurations
{
    public sealed class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable(nameof(Property));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(70);
                
            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CodeInternal)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(p => p.Year)
                .IsRequired();

            builder.Property(p => p.IdOwner)
                .IsRequired();
        }
    }
}
