using Microsoft.EntityFrameworkCore;

namespace ECommerceCompanyApplication.Models
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(order => order.OrderDate)
                .HasDefaultValueSql("GETDATE()");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
