using Mediator;
using Reborn.Fashion.Application.Interfaces;

namespace Reborn.Fashion.Application.UseCases.Listings;

public record SeedDataCommand() : ICommand;

public class SeedDataHandler : ICommandHandler<SeedDataCommand>
{
    private readonly IApplicationDbContext dbContext;
    private readonly IJobScheduler scheduler;

    public SeedDataHandler(IApplicationDbContext dbContext, IJobScheduler scheduler)
    {
        this.dbContext = dbContext;
        this.scheduler = scheduler;
    }

    public async ValueTask<Unit> Handle(
        SeedDataCommand request,
        CancellationToken cancellationToken
    )
    {
        dbContext.RemoveRange(dbContext.Listings);
        foreach (var listing in SeedData.Listings)
        {
            await dbContext.Listings.AddAsync(listing);
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        foreach (var listing in dbContext.Listings.ToArray())
        {
            await scheduler.ScheduleListingOpen(listing.Id, listing.DateRange.Start);
            if (listing.DateRange.Start > DateTime.UtcNow)
                listing.Publish();
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return default;
    }
}
