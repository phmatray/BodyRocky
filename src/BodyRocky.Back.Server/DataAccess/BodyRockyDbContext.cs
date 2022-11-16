using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.Server.DataAccess;

public sealed class BodyRockyDbContext 
    : IdentityDbContext<Customer, IdentityRole<Guid>, Guid>
{
    public BodyRockyDbContext(DbContextOptions<BodyRockyDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketProduct> BasketProducts { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ZipCode> ZipCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(BodyRockyDbContext).Assembly);
        
        // predefined data
        modelBuilder.Entity<Category>().HasData(ReferentialData.GetPredefinedCategories());
        modelBuilder.Entity<ZipCode>().HasData(ReferentialData.GetPredefinedZipCodes());
        modelBuilder.Entity<BasketStatus>().HasData(ReferentialData.GetPredefinedBasketStatuses());
        modelBuilder.Entity<OrderStatus>().HasData(ReferentialData.GetPredefinedOrderStatuses());
        
        // fake data
        FakeData.Init();
        modelBuilder.Entity<Brand>().HasData(FakeData.Brands!);
        modelBuilder.Entity<Customer>().HasData(FakeData.Customers!);
        modelBuilder.Entity<Address>().HasData(FakeData.Addresses!);
        modelBuilder.Entity<Product>().HasData(FakeData.Products!);
        modelBuilder.Entity<ProductCategory>().HasData(FakeData.ProductCategories!);
    }
}