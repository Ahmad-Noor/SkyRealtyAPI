using Sky.Domain.Base;

namespace Sky.Domain.Entities;
public class Currency : Entity, IAggregateRoot
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public float? Rate { get; set; }
    public string? Symbol { get; set; }

    protected override IEnumerable<object> GetIdentityComponents()
    {
        yield return Id;
    }
}