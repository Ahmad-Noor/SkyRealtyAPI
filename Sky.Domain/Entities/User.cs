using Sky.Domain.Base;

namespace Sky.Domain.Entities;
public class User : Entity, IAggregateRoot
{
    public long Id { get; set; }
    public string? Code { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public long? RoleId { get; set; }

    protected override IEnumerable<object> GetIdentityComponents()
    {
        yield return Id;
    }
}