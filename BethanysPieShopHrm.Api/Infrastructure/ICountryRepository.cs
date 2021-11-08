using System.Collections.Generic;
using BethanysPieShopHrmShared;

namespace BethanysPieShopHrm.Api.Infrastructure
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}