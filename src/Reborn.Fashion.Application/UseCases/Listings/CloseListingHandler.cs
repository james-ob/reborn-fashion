using Mediator;
using Reborn.Fashion.Application.Interfaces;

namespace Reborn.Fashion.Application.UseCases.Listings;

public record CloseListingCommand(Guid ListingId) : ICommand;

public class CloseListingHandler : ICommandHandler<CloseListingCommand>
{
    private readonly IApplicationDbContext dbContext;

    public CloseListingHandler(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(
        CloseListingCommand request,
        CancellationToken cancellationToken
    )
    {
        var listing =
            await dbContext.Listings.FindAsync(request.ListingId)
            ?? throw new ArgumentException("Listing not found");

        listing.Close();
        await dbContext.SaveChangesAsync(cancellationToken);

        return default;
    }
}
