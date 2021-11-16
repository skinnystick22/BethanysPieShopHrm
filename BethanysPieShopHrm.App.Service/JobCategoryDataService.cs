using System.Text.Json;
using BethanysPieShopHrmShared;

namespace BethanysPieShopHrm.App.Service;

public class JobCategoryDataService : IJobCategoryDataService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public JobCategoryDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
    }

    public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>(
            await _httpClient.GetStreamAsync("api/JobCategory"), _jsonSerializerOptions);
    }

    public async Task<JobCategory> GetJobCategoryById(int jobCategoryId)
    {
        return await JsonSerializer.DeserializeAsync<JobCategory>(
            await _httpClient.GetStreamAsync($"api/JobCategory/{jobCategoryId}"), _jsonSerializerOptions);
    }
}