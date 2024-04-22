using Microsoft.Extensions.DependencyInjection;

namespace Reborn.Fashion.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Transient;
        });
        return services;
    }
}
