using Mediator;
using Reborn.Fashion.Application.Interfaces;
using Reborn.Fashion.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Reborn.Fashion.Application.UseCases.Listings;

public record CreateListingCommand(string Title, string Description) : ICommand<Guid>;

[Mapper]
public static partial class CreateListingMapper
{
    public static partial Listing ToListing(CreateListingCommand request);
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
