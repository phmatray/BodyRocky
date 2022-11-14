using BodyRocky.Back.Server.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.Server.DataAccess.Configuration;

public class OrderedProductConfiguration : IEntityTypeConfiguration<OrderedProduct>
{
    public void Configure(EntityTypeBuilder<OrderedProduct> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("OrderedProduct")
            .HasKey(op => op.OrderedProductID);

        builder
            .Property(op => op.OrderedProductName)
            .IsRequired();
        
        builder
            .Property(op => op.OrderedProductDescription)
            .IsRequired();
        
        builder
            .Property(op => op.OrderedProductPrice)
            .HasColumnType("decimal(18,4)")
            .IsRequired();
        
        builder
            .Property(op => op.Quantity)
            .IsRequired();

        builder
            .HasOne(op => op.Product)
            .WithMany(product => product.OrderedProducts)
            .HasForeignKey(op => op.ProductID);
        
        builder
            .HasOne(op => op.Order)
            .WithMany(order => order.OrderedProducts)
            .HasForeignKey(op => op.OrderID);
        
        builder
            .HasOne(op => op.Product)
            .WithMany(product => product.OrderedProducts)
            .HasForeignKey(op => op.ProductID);
    }
}