using Sky.Domain.Base;

namespace Sky.Domain.Entities;
public class Customer : Entity, IAggregateRoot
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
    public long? AddressId { get; set; }
    public long? ContactId { get; set; }


    protected override IEnumerable<object> GetIdentityComponents()
    {
        yield return Id;
    }
}