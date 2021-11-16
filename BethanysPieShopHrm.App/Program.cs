using BethanysPieShopHrm.App.Service;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BethanysPieShopHrm.App;

public class Program
{
    private const string BaseUrl = "https://localhost:5002/";

    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(nameof(EmployeeDataService),
            client => client.BaseAddress = new Uri(BaseUrl));
        builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(nameof(CountryDataService),
            client => client.BaseAddress = new Uri(BaseUrl));
        builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(nameof(JobCategoryDataService),
            client => client.BaseAddress = new Uri(BaseUrl));

        await builder.Build().RunAsync();
    }
}