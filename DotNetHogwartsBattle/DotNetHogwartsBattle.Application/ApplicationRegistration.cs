using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetHogwartsBattle.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}