using BethanysPieShopHrmShared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BethanysPieShopHrm.Api.Data.EntityConfigurations;

public class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(c => c.CountryId)
            .IsClustered();

        builder.Property(c => c.Name)
            .HasMaxLength(255);

        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.HasData(
            new Country {CountryId = 1, Name = "Belgium"},
            new Country {CountryId = 2, Name = "Germany"},
            new Country {CountryId = 3, Name = "Netherlands"},
            new Country {CountryId = 4, Name = "USA"},
            new Country {CountryId = 5, Name = "Japan"},
            new Country {CountryId = 6, Name = "China"},
            new Country {CountryId = 7, Name = "UK"},
            new Country {CountryId = 8, Name = "France"},
            new Country {CountryId = 9, Name = "Brazil"}
        );
    }
}