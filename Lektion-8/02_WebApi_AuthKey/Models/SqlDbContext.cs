using _02_WebApi_AuthKey.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _02_WebApi_AuthKey.Models
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
