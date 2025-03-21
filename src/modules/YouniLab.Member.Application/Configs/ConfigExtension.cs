using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YouniLab.Member.Application.Configs
{
    public static class ConfigExtension
    {
        private const string ConfigSectionKey = "Configs";

        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Config>(configuration.GetSection(ConfigSectionKey));
            return services;
        }
    }
}
