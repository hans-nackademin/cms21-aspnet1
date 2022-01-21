using _01_WebApi_AspNetWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_WebApi_AspNetWebApi
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
        public virtual DbSet<CategoryEntity> Categories { get; set; }
    }
}
