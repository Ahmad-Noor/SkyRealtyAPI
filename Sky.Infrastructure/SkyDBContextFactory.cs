using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sky.Infrastructure
{
    public class SkyDBContextFactory : IDesignTimeDbContextFactory<SkyDBContext>
    {
        public SkyDBContext CreateDbContext(string[] args)
        {  
            var connectionString = "server=127.0.0.1;port=3306;database=SkyDB;uid=root;password=root;persistsecurityinfo=True;"; 
            return new SkyDBContext(connectionString);
        }
    }
}
