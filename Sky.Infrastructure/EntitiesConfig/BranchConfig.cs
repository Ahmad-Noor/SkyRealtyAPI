using Microsoft.EntityFrameworkCore;
using Sky.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sky.Infrastructure.EntitiesConfig
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches");
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Code).HasMaxLength(10);
            builder.Property(t => t.Name).HasMaxLength(150);
            builder.Property(t => t.CommercialNo).HasMaxLength(50);
            builder.Property(t => t.SiteURL).HasMaxLength(250);

            builder.HasData(BuildSeedData());

        }

        private List<Branch> BuildSeedData()
        {
            return new List<Branch>()  {
               new  Branch(){Id= 1,
                            Code= "001",
                            Name= "Main Branch",
                            LogoURL= null,
                            ShowLogo= null,
                            AddressId= null,
                            ContactId= null,
                            CommercialNo= null,
                            SiteURL= null,
                            DefaultCurrencyId= null,
                            DefaultInventoryId= null,
                            DefaultCostCenterId= null,
                            AccPurchasesId= null,
                            AccSuppliersId= null,
                            AccCashId= null,
                            AccPurchasesReturnsId= null,
                            AccSalesTaxonPurchasesId= null,
                            AccDiscountAcquiredId= null,
                            AccSalesId= null,
                            AccInventoryId= null,
                            AccSalesCostId= null,
                            InventoryAccountingTypes= null,
                            SystemType= null,
                            ClientId=1 } };
        }
    }
}
