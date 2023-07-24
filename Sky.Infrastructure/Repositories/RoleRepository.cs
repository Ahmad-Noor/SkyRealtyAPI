using Sky.Domain.Entities;
using Sky.Domain.Interfaces;


namespace Sky.Infrastructure.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(SkyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
