using Microsoft.EntityFrameworkCore;
using Sky.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sky.Infrastructure.EntitiesConfig
{
    public class InventoryConfig : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventories");
            builder.HasKey(o => o.Id);  
        } 
    }
}
