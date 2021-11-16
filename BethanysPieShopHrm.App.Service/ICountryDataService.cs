using BethanysPieShopHrmShared;

namespace BethanysPieShopHrm.App.Service;

public interface ICountryDataService
{
    Task<IEnumerable<Country>> GetAllCountries();
    Task<Country> GetCountryById(int countryId);
}