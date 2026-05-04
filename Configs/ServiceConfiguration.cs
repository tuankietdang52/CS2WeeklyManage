using CS2WeeklyManage.Repositories;
using CS2WeeklyManage.Repositories.Implementations;

namespace CS2WeeklyManage.Configs
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AllowCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();

            return services;
        }
    }
}