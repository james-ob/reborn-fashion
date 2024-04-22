using Mediator;
using Reborn.Fashion.Application.Interfaces;
using Reborn.Fashion.Domain.Entities;

namespace Reborn.Fashion.Application.UseCases.Listings;

public record PublishListingCommand(Guid ListingId) : ICommand;

public class PublishListingHandler : ICommandHandler<PublishListingCommand>
{
    private readonly IApplicationDbContext dbContext;

    public PublishListingHandler(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(
        PublishListingCommand request,
        CancellationToken cancellationToken
    )
    {
        var listing =
            await dbContext.Listings.FindAsync(request.ListingId)
            ?? throw new ArgumentException("Listing not found");

        listing.Publish();
        await dbContext.SaveChangesAsync(cancellationToken);

        return default;
    }
}
