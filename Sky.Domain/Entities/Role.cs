using Sky.Domain.Base;

namespace Sky.Domain.Entities;
public class Role : Entity, IAggregateRoot
{
    public long Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    protected override IEnumerable<object> GetIdentityComponents()
    {
        yield return Id;
    }
}
