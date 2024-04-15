using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Reborn.Fashion.Application.Interfaces;
using Reborn.Fashion.Infrastructure.Jobs;

namespace Reborn.Fashion.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("RebornFashionDatabase"))
        );

        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>()
        );

        services.AddScoped<IJobScheduler, JobScheduler>();

        services.AddQuartz();
        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        return services;
    }
}
