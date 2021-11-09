using System.Reflection;
using BethanysPieShopHrm.Api.Data;
using BethanysPieShopHrm.Api.Infrastructure;
using BethanysPieShopHrm.Api.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BethanysPieShopHrm.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName))
        );

        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();

        services.AddCors(options =>
            options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader()));

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "BethanysPieShopHrm.Api", Version = "v1"});
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BethanysPieShopHrm.Api v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseCors("Open");

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}