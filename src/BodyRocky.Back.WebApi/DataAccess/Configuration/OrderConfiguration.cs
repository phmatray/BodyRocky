using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.WebApi.DataAccess.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Order")
            .HasKey(order => order.OrderID);

        builder
            .Property(order => order.BillingName)
            .IsRequired();
        
        builder
            .Property(order => order.Reference)
            .IsRequired();
        
        builder
            .Property(order => order.DeliveryName)
            .IsRequired();
        
        builder
            .Property(order => order.PurchaseDate)
            .IsRequired();

        builder
            .HasOne(order => order.Address)
            .WithMany(address => address.Orders)
            .HasForeignKey(order => order.AddressId);

        builder
            .HasOne(order => order.OrderStatus)
            .WithMany(orderStatus => orderStatus.Orders)
            .HasForeignKey(order => order.OrderStatusCode);
        
        builder
            .HasMany(order => order.OrderedProducts)
            .WithOne(orderedProduct => orderedProduct.Order)
            .HasForeignKey(order => order.OrderedProductId);
    }
}