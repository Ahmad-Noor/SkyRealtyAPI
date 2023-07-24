using Microsoft.EntityFrameworkCore;
using Sky.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sky.Infrastructure.EntitiesConfig
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Code).HasMaxLength(10);
            builder.Property(t => t.Name).HasMaxLength(150);
            builder.Property(t => t.IsActive).HasMaxLength(10);
        }
    }
}
