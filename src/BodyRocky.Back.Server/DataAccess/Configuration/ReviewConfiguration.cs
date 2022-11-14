using BodyRocky.Back.Server.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.Server.DataAccess.Configuration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Review")
            .HasKey(review => review.ReviewID);

        builder
            .Property(review => review.ReviewRating)
            .IsRequired();

        builder
            .Property(review => review.ReviewText);
        
        builder
            .HasOne(review => review.Product)
            .WithMany(product => product.Reviews)
            .HasForeignKey(review => review.ProductID);
        
        builder
            .HasOne(review => review.Customer)
            .WithMany(customer => customer.Reviews)
            .HasForeignKey(review => review.CustomerID);
    }
}