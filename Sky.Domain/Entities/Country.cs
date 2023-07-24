using Sky.Domain.Base;

namespace Sky.Domain.Entities;
public class Country : Entity, IAggregateRoot
{
    public long Id { get; set; }
    public string CountryName { get; set; }

    protected override IEnumerable<object> GetIdentityComponents()
    {
        yield return Id;
    }
}