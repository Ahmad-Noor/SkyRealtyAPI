using Sky.Domain.Entities;
using Sky.Domain.Interfaces;

namespace Sky.Infrastructure.Repositories
{
    public class CurrencyRepository : RepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(SkyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
