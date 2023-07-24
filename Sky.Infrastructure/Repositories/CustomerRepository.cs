using Sky.Domain.Entities;
using Sky.Domain.Interfaces;

namespace Sky.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(SkyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
