using System.Text.Json;
using BethanysPieShopHrmShared;

namespace BethanysPieShopHrm.App.Service;

public class CountryDataService : ICountryDataService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public CountryDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        return await JsonSerializer.DeserializeAsync<List<Country>>(await _httpClient.GetStreamAsync("api/Country"),
            _jsonSerializerOptions);
    }

    public async Task<Country> GetCountryById(int countryId)
    {
        return await JsonSerializer.DeserializeAsync<Country>(
            await _httpClient.GetStreamAsync($"api/Country/{countryId}"), _jsonSerializerOptions);
    }
}