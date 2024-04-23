using Mediator;
using Reborn.Fashion.Application.Interfaces;
using Reborn.Fashion.Domain.Entities;

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
        Listing listing = await GetListing(request);

        listing.Open();
        await dbContext.SaveChangesAsync(cancellationToken);

        await ScheduleClose(listing);

        return default;
    }

    private async Task ScheduleClose(Listing listing)
    {
        if (listing.DateRange.End is not null)
            await scheduler.ScheduleListingClose(listing.Id, (DateTime)listing.DateRange.End);
    }

    private async Task<Listing> GetListing(OpenListingCommand request)
    {
        return await dbContext.Listings.FindAsync(request.ListingId)
            ?? throw new ArgumentException("Listing not found");
    }
}
