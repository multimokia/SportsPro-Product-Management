using Microsoft.EntityFrameworkCore;
using assignment1.Models;

namespace assignment1.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options): base(options) { }

        public DbSet<Product> Product { get; set; }

        public DbSet<assignment1.Models.Customer> Customer { get; set; }

        public DbSet<assignment1.Models.Technician> Technician { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Technician>().ToTable("Technician");
        }

    }
}
