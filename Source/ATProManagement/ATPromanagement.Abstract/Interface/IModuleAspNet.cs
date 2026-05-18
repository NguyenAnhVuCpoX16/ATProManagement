using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ATProManagement.Abstract
{
    public interface IModuleAspNet
    {
        void ConfigureServices(IServiceCollection services, IConfiguration config);

        //void BuildModule(IApplicationBuilder app);
    }
}
