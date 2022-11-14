using BodyRocky.Back.Server.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.Server.DataAccess.Configuration;

public class BasketStatusConfiguration: IEntityTypeConfiguration<BasketStatus>
{
    public void Configure(EntityTypeBuilder<BasketStatus> builder)
    {
        builder
            .ToTable("BasketStatus")
            .HasKey(status => status.Code);

        builder
            .Property(status => status.Description)
            .IsRequired();
    }
}