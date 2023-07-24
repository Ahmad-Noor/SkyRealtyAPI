using Sky.Domain.Base;

namespace Sky.Domain.Entities;
public class Address : Entity, IAggregateRoot
{
    public long Id { get; set; }
    public string Street { get; set; }
    public string? Line2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string? PostalCode { get; set; }
    public bool? IsActive { get; set; }
    public long? CountryId { get; set; }

    protected override IEnumerable<object> GetIdentityComponents()
    {
        yield return Id;
    }
}
