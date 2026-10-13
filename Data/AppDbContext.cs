using BrowsingTestApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BrowsingTestApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Keyboard", Price = 799, Stock = 25 },
            new Product { Id = 2, Name = "Mouse", Price = 399, Stock = 40 },
            new Product { Id = 3, Name = "Monitor", Price = 8999, Stock = 10 },
            new Product { Id = 4, Name = "Laptop Stand", Price = 1299, Stock = 15 },
            new Product { Id = 5, Name = "USB Hub", Price = 599, Stock = 30 },
            new Product { Id = 6, Name = "Webcam", Price = 2199, Stock = 12 },
            new Product { Id = 7, Name = "Headphones", Price = 1499, Stock = 20 },
            new Product { Id = 8, Name = "Mouse Pad", Price = 199, Stock = 50 },
            new Product { Id = 9, Name = "USB Cable", Price = 149, Stock = 60 },
            new Product { Id = 10, Name = "Speakers", Price = 1799, Stock = 8 }
        );
    }
}
