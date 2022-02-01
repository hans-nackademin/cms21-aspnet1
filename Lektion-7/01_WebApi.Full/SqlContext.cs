using _01_WebApi.Full.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_WebApi.Full
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; }
    }
}
