using Sky.Domain.Entities;
using Sky.Domain.Interfaces;

namespace Sky.Infrastructure.Repositories
{
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        public BranchRepository(SkyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
