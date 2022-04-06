using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using System.Linq;

namespace assignment1.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options): base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");

            var splitStringConverter = new ValueConverter<List<string>, string>(
                v => string.Join(";", v),
                v => _split(v).ToList()

            );

            modelBuilder.Entity<Customer>().ToTable("Customer")
                .Property(nameof(Customer.ProductIds))
                .HasConversion(splitStringConverter);

            modelBuilder.Entity<Technician>().ToTable("Technician");
            modelBuilder.Entity<Incident>().ToTable("Incident");
        }
        private static string[] _split(string toSplit)
        {
            return toSplit.Split(";");
        }
    }
}
