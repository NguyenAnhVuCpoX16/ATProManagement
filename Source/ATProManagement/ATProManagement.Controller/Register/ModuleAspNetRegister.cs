using ATProManagement.Base;
using ATProManagement.Service;
using ATProManagement.Abstract;
using ATProManagement.Core;
namespace ATProManagement.Controller
{
    public class ModuleAspNetRegister : IModuleAspNet
    {
        //public void BuildModule(IApplicationBuilder app)
        //{
        //    throw new NotImplementedException();
        //}

        public void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
