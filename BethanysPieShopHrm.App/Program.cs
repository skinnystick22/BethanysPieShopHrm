using System;
using System.Threading.Tasks;
using BethanysPieShopHrm.App.Service;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShopHrm.App;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>("Employee",
            client => client.BaseAddress = new Uri("https://localhost:5002/"));

        await builder.Build().RunAsync();
    }
}