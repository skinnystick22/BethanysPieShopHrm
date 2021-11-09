using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
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
        throw new System.NotImplementedException();
    }

    public async Task UpdateEmployee(Employee employee)
    {
        throw new System.NotImplementedException();
    }

    public async Task DeleteEmployee(int employeeId)
    {
        throw new System.NotImplementedException();
    }
}