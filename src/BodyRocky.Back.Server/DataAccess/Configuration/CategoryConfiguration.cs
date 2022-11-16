using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.Server.DataAccess.Configuration;

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
            .Property(category => category.CategoryImage)
            .IsRequired();
        
        builder
            .Property(category => category.CategoryIcon)
            .IsRequired();

        builder
            .Property(category => category.IsFeatured)
            .IsRequired();
    }
}