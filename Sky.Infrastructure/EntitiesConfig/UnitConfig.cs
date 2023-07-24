using Microsoft.EntityFrameworkCore;
using Sky.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sky.Infrastructure.EntitiesConfig
{
    public class UnitConfig : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units");
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Code).HasMaxLength(10);
            builder.Property(t => t.Name).HasMaxLength(150);
        }
    }
}
