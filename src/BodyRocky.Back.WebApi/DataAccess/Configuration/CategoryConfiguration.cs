using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.WebApi.DataAccess.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Category")
            .HasKey(category => category.CategoryID);
        
        builder
            .Property(category => category.CategoryName)
            .IsRequired();

        builder
            .Property(category => category.IsFeatured)
            .IsRequired();

        builder
            .HasMany(category => category.SubCategories)
            .WithOne(category => category.ParentCategory)
            .HasForeignKey(category => category.ParentCategoryID);
    }
}