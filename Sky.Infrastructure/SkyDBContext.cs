using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
 
namespace Sky.Infrastructure
{ 
    public class SkyDBContext : DbContext
    {
        private readonly string connectionString;

        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public SkyDBContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory).UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            //{
            //    sqlOptions.EnableRetryOnFailure(
            //    maxRetryCount: 10,
            //    maxRetryDelay: TimeSpan.FromSeconds(30),
            //    errorNumbersToAdd: null);
            //}).UseLowerCaseNamingConvention().UseLazyLoadingProxies();

            optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory).UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }
    } 
} 