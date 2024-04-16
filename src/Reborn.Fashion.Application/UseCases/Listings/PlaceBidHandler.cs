using Mediator;
using Microsoft.EntityFrameworkCore;
using Reborn.Fashion.Application.Interfaces;

namespace Reborn.Fashion.Application.UseCases.Listings;

public record PlaceBidCommand(Guid UserId, Guid ListingId, decimal Amount) : ICommand;

public class PlaceBidHandler : ICommandHandler<PlaceBidCommand>
{
    private readonly IApplicationDbContext dbContext;

    public PlaceBidHandler(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(
        PlaceBidCommand request,
        CancellationToken cancellationToken
    )
    {
        using var transaction = await dbContext.BeginTransaction();

        var listing =
            await dbContext
                .Listings.Include(l => l.Bids)
                .FirstOrDefaultAsync(l => l.Id == request.ListingId)
            ?? throw new ArgumentException("Listing not found");

        listing.PlaceBid(request.UserId, request.Amount);

        await dbContext.SaveChangesAsync(cancellationToken);
        transaction.Commit();

        return default;
    }
}
