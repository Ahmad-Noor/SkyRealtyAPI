using Sky.Domain.Entities;
using Sky.Domain.Interfaces;

namespace Sky.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SkyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
