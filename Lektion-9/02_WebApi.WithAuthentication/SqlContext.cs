using _02_WebApi.WithAuthentication.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _02_WebApi.WithAuthentication
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
