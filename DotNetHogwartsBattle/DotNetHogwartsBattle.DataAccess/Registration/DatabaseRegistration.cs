using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetHogwartsBattle.DataAccess.Registration;

public static class DatabaseRegistration
{
    public static IServiceCollection AddDatabaseRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<HogwartsBattleContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("db")));
        return services;
    }
}