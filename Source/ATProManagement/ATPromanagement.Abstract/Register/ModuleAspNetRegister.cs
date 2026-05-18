using ATProManagement.Context;
using ATProManagement.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ATProManagement.Abstract
{
    public class ModuleAspNetRegister : IModuleAspNet
    {
        //public void BuildModule(IApplicationBuilder app)
        //{
        //    throw new NotImplementedException();
        //}

        public void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IDbContext, AppDbContext>();

            services.AddScoped<IMyContext, MyContext>();
        }
    }
}
