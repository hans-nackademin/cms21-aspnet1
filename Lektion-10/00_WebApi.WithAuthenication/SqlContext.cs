using _00_WebApi.WithAuthenication.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _00_WebApi.WithAuthenication
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
