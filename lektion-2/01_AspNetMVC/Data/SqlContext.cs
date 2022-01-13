using _01_AspNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_AspNetMVC.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<ProductModel> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // om jag inte har en appsettings.json eller en app.config så gör jag såhär

            //if (!optionsBuilder.IsConfigured)
            //    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\CMS21\cms21-aspnet1\lektion-2\01_AspNetMVC\Data\efc_db.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
