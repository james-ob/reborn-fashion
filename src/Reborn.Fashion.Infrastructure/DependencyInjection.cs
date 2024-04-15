using Microsoft.Extensions.DependencyInjection;
using Reborn.Fashion.Application.Interfaces;

namespace Reborn.Fashion.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>()
        );

        return services;
    }
}
