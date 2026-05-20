using Microsoft.Extensions.DependencyInjection;

namespace ATProManagement.Base
{
    public static class BaseStatic
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ISweetAlertService, SweetAlerService>();
        }
    }
}
