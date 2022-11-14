using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.Server.DataAccess.Configuration;

public class RoleConfiguration
    : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        IdentityRole<Guid> adminRole = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR"
        };
        
        IdentityRole<Guid> customerRole = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Name = "Customer",
            NormalizedName = "CUSTOMER"
        };
        
        builder.HasData(customerRole, adminRole);
    }
}