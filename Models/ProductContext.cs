using Microsoft.EntityFrameworkCore;
using assignment1.Models;

namespace assignment1.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options): base(options) { }
        public DbSet<assignment1.Models.Product> Products { get; set; }
        public DbSet<assignment1.Models.Customer> Customers { get; set; }
        public DbSet<assignment1.Models.Technician> Technicians { get; set; }
        public DbSet<assignment1.Models.Incident> Incidents { get; set; }
        public DbSet<assignment1.Models.Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Technician>().ToTable("Technician");
            modelBuilder.Entity<Incident>().ToTable("Incident");
            modelBuilder.Entity<Registration>().ToTable("Registration");
        }

    }
}
