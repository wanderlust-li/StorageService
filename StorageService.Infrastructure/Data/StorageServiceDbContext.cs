using Microsoft.EntityFrameworkCore;
using StorageService.Domain.Entities;

namespace StorageService.Infrastructure.Data;

public class StorageServiceDbContext : DbContext
{
    public StorageServiceDbContext(DbContextOptions<StorageServiceDbContext> options) : base(options)
    {
    }

    public StorageServiceDbContext()
    {
    }

    public DbSet<Advertisement> Advertisements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advertisement>().HasData(
            new Advertisement()
            {
                Id = 1,
                Title = "First Item",
                Description = "This is a detailed description of the first item.",
                ImageUrl = "http://example.com/image1.jpg",
                Price = 100.50M
            },
            new Advertisement()
            {
                Id = 2,
                Title = "Second Item",
                Description = "This is a detailed description of the second item.",
                ImageUrl = "http://example.com/image2.jpg",
                Price = 250.00M
            }
        );
    }
}