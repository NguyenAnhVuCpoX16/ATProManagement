using ATPromanagement.Abstract;
using ATProManagement.Abstract;
using ATProManagement.Base;
using ATProManagement.Db;
using ATProManagement.Db.Entity;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using MudBlazor.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configs = builder.Configuration;
services.AddControllers();
// Add services to the container.
services.AddEndpointsApiExplorer();
//services.AddOpenApi();
services.AddHttpContextAccessor();
services.AddMudServices();
services.AddServerSideBlazor();
services.AddRazorPages();
services.AddSweetAlert2();
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

services.AddIdentity<EntityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});



var assemblies = AssembliesUtil.GetAspNetAssemblies();
var aspnetModules = assemblies.GetInstances<IModuleAspNet>();
foreach (var module in aspnetModules)
{
    module.ConfigureServices(services, configs);
}
services.AddScoped<ISweetAlertService, ATProMangement.Blazor.SweetAlertService>();
var app = builder.Build();
app.UseCors("AllowAll");
app.UseDefaultFiles();
app.MapStaticAssets();
app.MapControllers();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
