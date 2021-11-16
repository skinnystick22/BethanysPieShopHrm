using System.Text;
using System.Text.Json;
using BethanysPieShopHrmShared;

namespace BethanysPieShopHrm.App.Service;

public class EmployeeDataService : IEmployeeDataService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public EmployeeDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
            await _httpClient.GetStreamAsync("api/employee"),
            _jsonSerializerOptions);
    }

    public async Task<Employee> GetEmployeeDetails(int employeeId)
    {
        return await JsonSerializer.DeserializeAsync<Employee>(
            await _httpClient.GetStreamAsync($"api/employee/{employeeId}"),
            _jsonSerializerOptions);
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("api/Employee", employeeJson);

        if (response.IsSuccessStatusCode)
        {
            return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
        }

        return null;
    }

    public async Task UpdateEmployee(Employee employee)
    {
        var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

        await _httpClient.PutAsync("api/Employee", employeeJson);
    }

    public async Task DeleteEmployee(int employeeId)
    {
        await _httpClient.DeleteAsync($"api/Employee/{employeeId}");
    }
}