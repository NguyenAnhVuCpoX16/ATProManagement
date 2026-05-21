using ATPromanagement.Abstract;
using ATProManagement.Abstract;
using ATProManagement.Context;
using ATProManagement.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configs = builder.Configuration;
// Add services to the container.

services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddOpenApi();
services.AddEndpointsApiExplorer();
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

services.AddDbContext<AppDbContext>(options =>
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

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
