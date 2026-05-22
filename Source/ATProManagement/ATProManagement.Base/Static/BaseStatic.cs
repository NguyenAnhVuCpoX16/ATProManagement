using ATProManagement.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ATProManagement.Base
{
    public static class BaseStatic
    {
        public static bool IsDesktop = false;

        public static void Register(IServiceCollection services)
        {
            services.AddScoped<LayoutStateService>();
            services.AddScoped<IMyCookie, MyCookie>();
        }
    }
}
