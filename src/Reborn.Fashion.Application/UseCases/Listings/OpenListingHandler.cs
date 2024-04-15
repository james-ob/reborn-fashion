using Mediator;
using Reborn.Fashion.Application.Interfaces;

namespace Reborn.Fashion.Application.UseCases.Listings;

public record OpenListingCommand(Guid ListingId) : ICommand;

public class OpenListingHandler : ICommandHandler<OpenListingCommand>
{
    private readonly IApplicationDbContext dbContext;

    public OpenListingHandler(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
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

        return default;
    }
}
