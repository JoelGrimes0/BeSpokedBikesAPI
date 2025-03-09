using BeSpokedBikesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikesAPI.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Road Bike", Manufacturer = "Trek", Style = "Racing", PurchasePrice = 500, SalePrice = 1000, QtyOnHand = 10, CommissionPercentage = 10 },
                new Product { Id = 2, Name = "Mountain Bike", Manufacturer = "Giant", Style = "Off-Road", PurchasePrice = 800, SalePrice = 1500, QtyOnHand = 5, CommissionPercentage = 12 },
                new Product { Id = 3, Name = "Hybrid Bike", Manufacturer = "Specialized", Style = "Casual", PurchasePrice = 300, SalePrice = 700, QtyOnHand = 15, CommissionPercentage = 8 }
            );

            // Seed Salespersons
            modelBuilder.Entity<Salesperson>().HasData(
                new Salesperson { Id = 1, FirstName = "John", LastName = "Doe", Address = "123 Main St", Phone = "555-1234", StartDate = new DateTime(2020, 1, 10), Manager = "Alice" },
                new Salesperson { Id = 2, FirstName = "Jane", LastName = "Smith", Address = "456 Oak St", Phone = "555-5678", StartDate = new DateTime(2021, 5, 15), Manager = "Bob" }
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "Michael", LastName = "Johnson", Address = "789 Pine St", Phone = "555-9876", StartDate = new DateTime(2022, 3, 1) },
                new Customer { Id = 2, FirstName = "Emily", LastName = "Williams", Address = "321 Cedar St", Phone = "555-6543", StartDate = new DateTime(2021, 8, 20) }
            );

            // Seed Sales
            modelBuilder.Entity<Sale>().HasData(
                new Sale { Id = 1, ProductId = 1, SalespersonId = 1, CustomerId = 1, SalesDate = new DateTime(2023, 1, 5), SalePrice = 1000 },
                new Sale { Id = 2, ProductId = 2, SalespersonId = 2, CustomerId = 2, SalesDate = new DateTime(2023, 2, 10), SalePrice = 1500 }
            );

            // Seed Discounts
            modelBuilder.Entity<Discount>().HasData(
                new Discount { Id = 1, ProductId = 1, BeginDate = new DateTime(2023, 1, 1), EndDate = new DateTime(2023, 1, 31), DiscountPercentage = 10 }
            );
        }
    }
}
