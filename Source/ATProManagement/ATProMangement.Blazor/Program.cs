using ATPromanagement.Abstract;
using ATProManagement.Abstract;
using ATProManagement.Context;
using ATProManagement.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configs = builder.Configuration;
services.AddControllers();
// Add services to the container.
services.AddEndpointsApiExplorer();
//services.AddOpenApi();
services.AddMudServices();
services.AddServerSideBlazor();
services.AddRazorPages();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ATProManagement",
        Version = "v1"
    });
});

services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

services.AddDbContextFactory<AppDbContext>(options =>
    options.UseMySql(
        configs.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(configs.GetConnectionString("mysql"))
    )
);
var assemblies = AssembliesUtil.GetAspNetAssemblies();
var aspnetModules = assemblies.GetInstances<IModuleAspNet>();
foreach (var module in aspnetModules)
{
    module.ConfigureServices(services, configs);
}
var app = builder.Build();
app.UseCors("AllowAll");
app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ATProManagement API V1");

    // Hide Schemas
    c.DefaultModelsExpandDepth(-1);
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
