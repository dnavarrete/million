using Microsoft.EntityFrameworkCore;
using Million.Core.Entities;
using Million.Infrastructure.TypeConfigurations;

namespace Million.Infrastructure
{
    public class MillionContext : DbContext
    {
        public MillionContext(DbContextOptions<MillionContext> options) : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; } = null!;

        public DbSet<PropertyImage> PropertyImages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyImageConfiguration());
        }
    }
}
