using _00_AspNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace _00_AspNetMVC
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<ProductSubCategoryEntity> ProductSubCategories { get; set; }
        public virtual DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    }
}
