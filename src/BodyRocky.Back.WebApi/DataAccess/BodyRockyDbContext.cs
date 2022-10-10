using BodyRocky.Back.WebApi.DataAccess.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.WebApi.DataAccess;

public sealed class BodyRockyDbContext : DbContext
{
    public BodyRockyDbContext(DbContextOptions options)
        : base(options)
    {
    }
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Adresses { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ZipCode> ZipCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(BodyRockyDbContext).Assembly);

        modelBuilder
            .Entity<Customer>()
            .HasData(DataFakers.FakerCustomer.Generate(100));

        modelBuilder
            .Entity<Category>()
            .HasData(DataFakers.FakerCategory.Generate(3));
        
        modelBuilder
            .Entity<Address>()
            .HasData(DataFakers.FakerAddress.Generate(100));
    }
}