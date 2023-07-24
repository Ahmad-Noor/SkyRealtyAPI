using Sky.Domain.Base;

namespace Sky.Domain.Entities;
public class Inventory : Entity, IAggregateRoot
{
    public long Id { get; set; }
    public long? BranchId { get; set; }
    public string? InventoryCode { get; set; }
    public string? InventoryName { get; set; }
    public long? AddressId { get; set; }
    public string? PostalCode { get; set; }
    public string? Storekeeper { get; set; }
     
    protected override IEnumerable<object> GetIdentityComponents()
    {
        yield return Id;
    }
}