using System;
using System.Threading.Tasks;
using BethanysPieShopHRM.App.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShopHRM.Client;

public class Program
{
    private const string BaseUrl = "https://localhost:44340/";

    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App.App>("app");

        builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client =>
            client.BaseAddress = new Uri(BaseUrl));
        builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client =>
            client.BaseAddress = new Uri(BaseUrl));
        builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(client =>
            client.BaseAddress = new Uri(BaseUrl));

        await builder.Build().RunAsync();
    }
}