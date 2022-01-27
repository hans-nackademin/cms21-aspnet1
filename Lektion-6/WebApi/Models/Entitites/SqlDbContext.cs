using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.Entitites
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {

        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public DbSet<StatusEntity> Statuses { get; set; }
        public DbSet<HandlerEntity> Handlers { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CaseEntity> Cases { get; set; }
        public DbSet<CaseHandlerEntity> CaseHandlers { get; set; }
    }
}
