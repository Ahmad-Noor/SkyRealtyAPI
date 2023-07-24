using Microsoft.EntityFrameworkCore;
using Sky.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sky.Infrastructure.EntitiesConfig
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(o => o.Id);  
        } 
    }
}
