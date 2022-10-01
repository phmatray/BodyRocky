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
        var fakerCustomer = new Faker<Customer>()
            .RuleFor(m => m.CustomerID, f => f.Random.Guid())
            .RuleFor(m => m.FirstName, f => f.Person.FirstName)
            .RuleFor(m => m.LastName, f => f.Person.LastName)
            .RuleFor(m => m.BirthDate, f => f.Date.Past(18))
            .RuleFor(m => m.Password, f => f.Random.Hash())
            .RuleFor(m => m.PhoneNumber, f => f.Person.Phone)
            .RuleFor(m => m.EmailAddress, f => f.Person.Email);

        modelBuilder
            .Entity<Customer>()
            .HasData(fakerCustomer.Generate(1000));
    }
}