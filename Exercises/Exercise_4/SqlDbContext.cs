using Exercise_4.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercise_4
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {

        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }


        public virtual DbSet<AddressEntity> Addresses { get; set; }
        public virtual DbSet<CustomerEntity> Customers { get; set; }
        public virtual DbSet<HandlerEntity> Handlers { get; set; }
        public virtual DbSet<CaseStatusEntity> CaseStatuses { get; set; }
        public virtual DbSet<CaseEntity> Cases { get; set; }
        public virtual DbSet<CaseHandlerEntity> CaseHandlers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseHandlerEntity>().HasKey(c => new { c.CaseId, c.HandlerId });
        }
    }
}
