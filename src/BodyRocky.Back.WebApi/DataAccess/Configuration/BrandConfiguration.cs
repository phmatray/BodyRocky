using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.WebApi.DataAccess.Configuration;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder
            .ToTable("Brand")
            .HasKey(brand => brand.BrandID);

        builder
            .Property(brand => brand.BrandName)
            .IsRequired();

        builder
            .Property(brand => brand.BrandLogo)
            .IsRequired();
    }
}