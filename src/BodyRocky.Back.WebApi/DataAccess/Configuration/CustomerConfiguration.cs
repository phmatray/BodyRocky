using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.WebApi.DataAccess.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Customer")
            .HasKey(customer => customer.CustomerID);

        builder
            .Property(customer => customer.FirstName)
            .IsRequired();
        
        builder
            .Property(customer => customer.LastName)
            .IsRequired();
        
        builder
            .Property(customer => customer.BirthDate)
            .IsRequired();
        
        builder
            .Property(customer => customer.Password)
            .IsRequired();
        
        builder
            .Property(customer => customer.PhoneNumber)
            .IsRequired();
        
        builder
            .Property(customer => customer.EmailAddress)
            .IsRequired();

        builder
            .HasMany(customer => customer.Addresses)
            .WithOne(address => address.Customer)
            .HasForeignKey(customer => customer.AddressID);
        
        builder
            .HasMany(customer => customer.Baskets)
            .WithOne(basket => basket.Customer)
            .HasForeignKey(customer => customer.BasketID);
        
        builder
            .HasMany(customer => customer.Reviews)
            .WithOne(review => review.Customer)
            .HasForeignKey(customer => customer.ReviewID);
        
        builder
            .HasMany(customer => customer.Orders)
            .WithOne(order => order.Customer)
            .HasForeignKey(customer => customer.OrderID);
    }
}