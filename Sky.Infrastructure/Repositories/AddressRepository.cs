using Sky.Domain.Entities;
using Sky.Domain.Interfaces;

namespace Sky.Infrastructure.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(SkyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
