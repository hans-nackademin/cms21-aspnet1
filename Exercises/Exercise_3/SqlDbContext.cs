using Exercise_3.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Exercise_3
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {

        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public virtual DbSet<CategoryEntity> Categories { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }
    }
}
