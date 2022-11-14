using BodyRocky.Back.Server.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.Server.DataAccess.Configuration;

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
            .HasOne(order => order.BillingAddress)
            .WithMany(address => address.BilledOrders)
            .HasForeignKey(order => order.BillingAddressID);

        builder
            .HasOne(order => order.DeliveryAddress)
            .WithMany(address => address.DeliveredOrders)
            .HasForeignKey(order => order.DeliveryAddressID)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(order => order.OrderStatus)
            .WithMany(orderStatus => orderStatus.Orders)
            .HasForeignKey(order => order.OrderStatusCode);
        
        builder
            .HasOne(order => order.Customer)
            .WithMany(customer => customer.Orders)
            .HasForeignKey(order => order.CustomerID);
    }
}