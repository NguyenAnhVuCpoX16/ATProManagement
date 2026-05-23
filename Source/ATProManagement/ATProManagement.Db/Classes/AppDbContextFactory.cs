using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ATProManagement.Db
{
    public class AppDbContextFactory
        : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder =
                new DbContextOptionsBuilder<AppDbContext>();

            var configuration =
                new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString =
                configuration.GetConnectionString("mysql");

            builder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );

            return new AppDbContext(builder.Options);
        }
    }
}