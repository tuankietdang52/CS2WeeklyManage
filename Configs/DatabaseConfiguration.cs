using CS2WeeklyManage.Models.Commons;
using Microsoft.EntityFrameworkCore;

namespace CS2WeeklyManage.Configs
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, ConfigurationManager configuration)
        {
            string? connection = configuration.GetConnectionString("MyDb");

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(connection));

            return services;
        }
    }
}