using Sky.Domain.Base;
using Sky.Domain.Interfaces;

namespace Sky.Domain
{
    public interface IUnitOfWork
    {

        IBranchRepository BranchRepository { get; }
        IAddressRepository AddressRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        ICountryRepository CountryRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IUnitRepository UnitRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        Task<int> SaveChangesAsync();
        IRepository<T> AsyncRepository<T>() where T : Entity;
    }
}
