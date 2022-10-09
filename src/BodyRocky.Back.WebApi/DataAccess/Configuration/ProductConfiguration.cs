using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.WebApi.DataAccess.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Product")
            .HasKey(product => product.ProductId);

        builder
            .HasOne(product => product.Brand)
            .WithMany(brand => brand.Products)
            .HasForeignKey(product => product.BrandId);

        builder
            .HasMany(product => product.ProductImages)
            .WithOne(image => image.Product)
            .HasForeignKey(product => product.ProductImageID);

        builder
            .HasMany(product => product.Reviews)
            .WithOne(review => review.Product)
            .HasForeignKey(product => product.ReviewID);
        
        builder
            .HasMany(product => product.OrderedProducts)
            .WithOne(orderedProduct => orderedProduct.Product)
            .HasForeignKey(product => product.OrderedProductId);
 
        builder
            .Property(product => product.ProductName)
            .IsRequired();
        
        builder
            .Property(product => product.ProductDescription)
            .IsRequired();
        
        builder
            .Property(product => product.ProductPrice)
            .HasColumnType("decimal(18,4)")
            .IsRequired();
        
        builder
            .Property(product => product.ProductURL)
            .IsRequired();
        
        builder
            .Property(product => product.IsFeatured)
            .IsRequired();
    }
}