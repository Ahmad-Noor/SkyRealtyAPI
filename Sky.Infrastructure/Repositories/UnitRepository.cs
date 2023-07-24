using Sky.Domain.Entities;
using Sky.Domain.Interfaces;

namespace Sky.Infrastructure.Repositories
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
        public UnitRepository(SkyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
