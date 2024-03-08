using Infrastructure.Database.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.EntityFramework.Settings
{
    public class EFContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<OrderItemModel> OrderItem { get; set; }

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
            //modelBuilder.Entity<OrderModel>()
            //    .HasMany(o => o.Items)
            //    .WithOne(i => i.Order)
            //    .HasForeignKey(i => i.OrderId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<CustomerModel>()
            //    .HasMany(c => c.Orders)
            //    .WithOne(o => o.Customer)
            //    .HasForeignKey(o => o.CustomerId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
