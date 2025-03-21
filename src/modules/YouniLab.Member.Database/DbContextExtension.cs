using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace YouniLab.Member.Database
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, string connection)
        {
            services.AddDbContext<MemberDbContext>(options =>
            {
                options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            });

            services.AddScoped<DbContext>(sp => sp.GetRequiredService<MemberDbContext>());

            return services;
        }
    }
}
