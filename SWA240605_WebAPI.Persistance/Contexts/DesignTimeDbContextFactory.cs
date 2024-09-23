using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace SWA240605_WebAPI.Persistance.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=AT-DT-007;Database=SWA240605;Trusted_Connection=true;Encrypt=False;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
