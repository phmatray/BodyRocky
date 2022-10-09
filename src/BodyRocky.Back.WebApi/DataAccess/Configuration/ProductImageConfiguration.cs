﻿using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.WebApi.DataAccess.Configuration;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("ProductImage")
            .HasKey(productImage => productImage.ProductImageID);

        builder
            .Property(productImage => productImage.Image)
            .IsRequired();
        
        builder
            .Property(productImage => productImage.IsFeatured)
            .IsRequired();

        builder
            .HasOne(productImage => productImage.Product)
            .WithMany(product => product.ProductImages)
            .HasForeignKey(productImage => productImage.ProductId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
    
}