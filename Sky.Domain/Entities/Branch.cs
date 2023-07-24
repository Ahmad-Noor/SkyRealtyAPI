using Sky.Domain.Base;

namespace Sky.Domain.Entities;
public class Branch : Entity, IAggregateRoot
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? LogoURL { get; set; }
    public bool? ShowLogo { get; set; }
    public long? AddressId { get; set; }
    public long? ContactId { get; set; }
    public string? CommercialNo { get; set; }
    public string? SiteURL { get; set; }
    public long? DefaultCurrencyId { get; set; }
    public long? DefaultInventoryId { get; set; }
    public long? DefaultCostCenterId { get; set; }
    public long? AccPurchasesId { get; set; }
    public long? AccSuppliersId { get; set; }
    public long? AccCashId { get; set; }
    public long? AccPurchasesReturnsId { get; set; }
    public long? AccSalesTaxonPurchasesId { get; set; }
    public long? AccDiscountAcquiredId { get; set; }
    public long? AccSalesId { get; set; }
    public long? AccInventoryId { get; set; }
    public long? AccSalesCostId { get; set; }
    public int? InventoryAccountingTypes { get; set; }
    public int? SystemType { get; set; }


    protected override IEnumerable<object> GetIdentityComponents()
    {
        yield return Id;
    }
}