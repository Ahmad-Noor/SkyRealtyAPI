using Microsoft.EntityFrameworkCore;
using Sky.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sky.Infrastructure.EntitiesConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Code).HasMaxLength(10);
            builder.Property(t => t.Email).HasMaxLength(100);
            builder.Property(t => t.Password).HasMaxLength(100);

            builder.HasData(BuildSeedData());

        }

        private List<User> BuildSeedData()
        {
            return new List<User>()  {
               new  User(){Id=1,
                            Code ="001",
                            FirstName="admin",
                            LastName="admin",
                            UserName="admin",
                            Password="qKkxoCVZkDE+Mr9Yobrs5RGQBfngHc0SnKXDOn0m1LmarY/c",
                            Email ="admin@admin.com",
                            ClientId=1 } };
        }
    }
}
