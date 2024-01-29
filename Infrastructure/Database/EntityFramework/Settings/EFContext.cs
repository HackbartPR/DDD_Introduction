using Infrastructure.Database.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.EntityFramework.Settings
{
    public class EFContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("SqliteConnectionString: Data Source=../DB.sqlite");
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
