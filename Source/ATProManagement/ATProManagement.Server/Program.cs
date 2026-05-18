using ATPromanagement.Abstract;
using ATProManagement.Abstract;
using ATProManagement.Context;
using ATProManagement.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configs = builder.Configuration;
// Add services to the container.

services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddOpenApi();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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

services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        configs.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(configs.GetConnectionString("mysql"))
    )
);
services.AddScoped<IDbContext>(
    x => x.GetRequiredService<AppDbContext>()
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
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
