using Exercise_2.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Exercise_2
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
