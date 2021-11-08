using BethanysPieShopHrmShared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BethanysPieShopHrm.Api.Data.EntityConfigurations
{
    public class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new Country { CountryId = 1, Name = "Belgium" });
            builder.HasData(new Country { CountryId = 2, Name = "Germany" });
            builder.HasData(new Country { CountryId = 3, Name = "Netherlands" });
            builder.HasData(new Country { CountryId = 4, Name = "USA" });
            builder.HasData(new Country { CountryId = 5, Name = "Japan" });
            builder.HasData(new Country { CountryId = 6, Name = "China" });
            builder.HasData(new Country { CountryId = 7, Name = "UK" });
            builder.HasData(new Country { CountryId = 8, Name = "France" });
            builder.HasData(new Country { CountryId = 9, Name = "Brazil" });
        }
    }
}