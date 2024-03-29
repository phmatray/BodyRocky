﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.Server.DataAccess.Configuration;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Basket")
            .HasKey(basket => basket.BasketID);

        builder
            .Property(basket => basket.BasketDateAdded)
            .IsRequired();
        
        builder
            .HasOne(basket => basket.BasketStatus)
            .WithMany(status => status.Baskets)
            .HasForeignKey(basket => basket.BasketStatusCode)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(basket => basket.Customer)
            .WithMany(customer => customer.Baskets)
            .HasForeignKey(basket => basket.CustomerID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}