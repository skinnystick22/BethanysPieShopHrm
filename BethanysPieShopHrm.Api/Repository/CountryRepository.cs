using System.Collections.Generic;
using System.Linq;
using BethanysPieShopHrm.Api.Data;
using BethanysPieShopHrm.Api.Infrastructure;
using BethanysPieShopHrmShared;

namespace BethanysPieShopHrm.Api.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CountryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _appDbContext.Countries;
        }

        public Country GetCountryById(int countryId)
        {
            return _appDbContext.Countries.FirstOrDefault(c => c.CountryId == countryId);
        }
    }
}
