using Sky.Domain;
using Sky.Domain.Base;
using Microsoft.Extensions.Logging;
using Sky.Infrastructure.Repositories;
using Sky.Domain.Interfaces;

namespace Sky.Infrastructure;
public class UnitOfWork : IUnitOfWork, IAsyncDisposable
{
    private readonly SkyDBContext dbContext;
    private readonly ILogger<UnitOfWork> logger;

    public UnitOfWork(IDatabaseConnectionString databaseConnectionString, ILogger<UnitOfWork> logger)
    {
        dbContext = new SkyDBContext(databaseConnectionString.ConnectionString);
        this.logger = logger;
    }

    private IBranchRepository branchRepository;
    private IAddressRepository addressRepository;
    private ICurrencyRepository currencyRepository;
    private IInventoryRepository inventoryRepository;
    private ICountryRepository countryRepository;
    private IUnitRepository unitRepository;
    private ICustomerRepository customerRepository;
    private IUserRepository userRepository;
    private IRoleRepository roleRepository;


    public IBranchRepository BranchRepository => branchRepository ??= new BranchRepository(dbContext);
    public IAddressRepository AddressRepository => addressRepository ??= new AddressRepository(dbContext);
    public ICurrencyRepository CurrencyRepository => currencyRepository ??= new CurrencyRepository(dbContext);
    public IInventoryRepository InventoryRepository => inventoryRepository ??= new InventoryRepository(dbContext);
    public ICountryRepository CountryRepository => countryRepository ??= new CountryRepository(dbContext);
    public IUnitRepository UnitRepository => unitRepository ??= new UnitRepository(dbContext);
    public ICustomerRepository CustomerRepository => customerRepository ??= new CustomerRepository(dbContext);
    public IUserRepository UserRepository => userRepository ??= new UserRepository(dbContext);
    public IRoleRepository RoleRepository => roleRepository ??= new RoleRepository(dbContext);

    public IRepository<T> AsyncRepository<T>() where T : Entity
    {
        return new RepositoryBase<T>(dbContext);
    }

    public Task<int> SaveChangesAsync()
    {
        return dbContext.SaveChangesAsync();
    }
    /// <summary>
    /// No matter an exception has been raised or not, 
    /// this method always will dispose the DbContext 
    /// </summary>
    /// <returns></returns>
    ValueTask IAsyncDisposable.DisposeAsync()
    {
        return dbContext.DisposeAsync();
    }
}
