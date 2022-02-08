using _01_WebApi.WithApiKey.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_WebApi.WithApiKey
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; }
    }
}
