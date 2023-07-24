using Sky.Domain.Entities;
using Sky.Domain.Interfaces;

namespace Sky.Infrastructure.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(SkyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
