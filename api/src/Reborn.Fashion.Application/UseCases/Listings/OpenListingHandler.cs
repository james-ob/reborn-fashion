using Mediator;
using Reborn.Fashion.Application.Interfaces;

namespace Reborn.Fashion.Application.UseCases.Listings;

public record OpenListingCommand(Guid ListingId) : ICommand;

public class OpenListingHandler : ICommandHandler<OpenListingCommand>
{
    private readonly IApplicationDbContext dbContext;
    private readonly IJobScheduler scheduler;

    public OpenListingHandler(IApplicationDbContext dbContext, IJobScheduler scheduler)
    {
        this.dbContext = dbContext;
        this.scheduler = scheduler;
    }

    public async ValueTask<Unit> Handle(
        OpenListingCommand request,
        CancellationToken cancellationToken
    )
    {
        var listing =
            await dbContext.Listings.FindAsync(request.ListingId)
            ?? throw new ArgumentException("Listing not found");

        listing.Open();
        await dbContext.SaveChangesAsync(cancellationToken);

        if (listing.DateRange.End is not null)
            await scheduler.ScheduleListingClose(listing.Id, (DateTime)listing.DateRange.End);

        return default;
    }
}
