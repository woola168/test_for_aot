using Microsoft.Extensions.DependencyInjection;
using YouniLab.Member.Application.AppServices;

namespace YouniLab.Member.Application.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<MemberAppService>();

            return services;
        }
    }
}
