using Microsoft.EntityFrameworkCore;
using SecurityServicesLogging.Business.Model;

namespace SecurityServicesLogging.Repository.Context
{
    public class DBContext
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
                this.Database.EnsureCreated();
            }

            public DbSet<SecurityLog> SecurityLogs { get; set; }
        }
    }
}
