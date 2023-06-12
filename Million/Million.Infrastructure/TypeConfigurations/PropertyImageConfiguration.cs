using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Million.Core.Entities;

namespace Million.Infrastructure.TypeConfigurations
{
    public sealed class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable(nameof(PropertyImage));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("IdPropertyImage");

            builder.Property(p => p.File)
                .IsRequired()
                .HasMaxLength(int.MaxValue);

            builder.Property(p => p.Enabled)
                .IsRequired();
        }
    }
}
