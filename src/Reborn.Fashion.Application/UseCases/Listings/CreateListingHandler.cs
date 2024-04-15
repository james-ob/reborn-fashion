using Mediator;
using Reborn.Fashion.Application.Interfaces;
using Reborn.Fashion.Domain.Entities;
using Reborn.Fashion.Domain.ValueObjects;
using Riok.Mapperly.Abstractions;

namespace Reborn.Fashion.Application.UseCases.Listings;

public record CreateListingCommand(string Title, string Description, DateTime Start, DateTime? End)
    : ICommand<Guid>;

[Mapper]
public static partial class CreateListingMapper
{
    private static partial Listing ToListingMapping(CreateListingCommand request);

    public static Listing ToListing(CreateListingCommand request)
    {
        var listing = ToListingMapping(request);
        var dateRange = new DateRange(request.Start, request.End);
        listing.DateRange = dateRange;
        return listing;
    }
}

public class CreateListingHandler : ICommandHandler<CreateListingCommand, Guid>
{
    private readonly IApplicationDbContext dbContext;

    public CreateListingHandler(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(
        CreateListingCommand request,
        CancellationToken cancellationToken
    )
    {
        var listing = CreateListingMapper.ToListing(request);
        await dbContext.Listings.AddAsync(listing);
        await dbContext.SaveChangesAsync(cancellationToken);

        return listing.Id;
    }
}
