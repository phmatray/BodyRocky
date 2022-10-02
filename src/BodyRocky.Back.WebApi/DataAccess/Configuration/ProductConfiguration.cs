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
            .HasForeignKey(image => image.ProductId);
 
        builder
            .Property(product => product.ProductName)
            .IsRequired();
        
        builder
            .Property(product => product.ProductDescription)
            .IsRequired();
        
        builder
            .Property(product => product.ProductPrice)
            .IsRequired();
        
        builder
            .Property(product => product.ProductURL)
            .IsRequired();
        
        builder
            .Property(product => product.IsFeatured)
            .IsRequired();
    }
}