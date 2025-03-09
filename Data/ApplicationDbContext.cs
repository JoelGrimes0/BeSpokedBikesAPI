using Microsoft.EntityFrameworkCore;
using BeSpokedBikesAPI.Models;


namespace BeSpokedBikesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Salesperson> Salespersons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply Unique Constraints
            modelBuilder.Entity<Product>()
                .HasIndex(p => new { p.Name, p.Manufacturer, p.Style })
                .IsUnique();

            modelBuilder.Entity<Salesperson>()
                .HasIndex(s => new { s.FirstName, s.LastName, s.Phone })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.Username })
                .IsUnique();

            // Seed Initial Data
            modelBuilder.SeedData();
        }
    }
}
