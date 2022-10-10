using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.WebApi.DataAccess;

public sealed class BodyRockyDbContext : DbContext
{
    public BodyRockyDbContext(DbContextOptions options)
        : base(options)
    {
    }
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
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

        FakeData.Init();
        modelBuilder.Entity<Brand>().HasData(FakeData.Brands!);
        modelBuilder.Entity<Category>().HasData(FakeData.Categories!);
        modelBuilder.Entity<Customer>().HasData(FakeData.Customers!);
        modelBuilder.Entity<ZipCode>().HasData(FakeData.ZipCodes!);
        // modelBuilder.Entity<Address>().HasData(FakeData.Addresses!);
    }
}