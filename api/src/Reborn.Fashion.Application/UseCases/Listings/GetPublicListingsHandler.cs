using Mediator;
using Reborn.Fashion.Application.Interfaces;
using Reborn.Fashion.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Reborn.Fashion.Application.UseCases.Listings;

public record GetPublicListingsResponse(
    Guid Id,
    string Title,
    string Description,
    string ImageSrc,
    DateTime Start,
    DateTime? End,
    ListingStatus Status
);

public record GetPublicListingsRequest() : IRequest<GetPublicListingsResponse[]>;

[Mapper]
public static partial class GetPublicListingsMapper
{
    [MapProperty(
        [nameof(Listing.DateRange), nameof(Listing.DateRange.Start)],
        [nameof(GetListingResponse.Start)]
    )]
    [MapProperty(
        [nameof(Listing.DateRange), nameof(Listing.DateRange.End)],
        [nameof(GetListingResponse.End)]
    )]
    public static partial GetPublicListingsResponse ToGetPublicListingsResponse(Listing listing);
}

public class GetPublicListingsHandler
    : IRequestHandler<GetPublicListingsRequest, GetPublicListingsResponse[]>
{
    private readonly IApplicationDbContext dbContext;

    public GetPublicListingsHandler(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask<GetPublicListingsResponse[]> Handle(
        GetPublicListingsRequest request,
        CancellationToken cancellationToken
    )
    {
        var listings = dbContext
            .Listings.Where(l =>
                l.Status == ListingStatus.Published || l.Status == ListingStatus.Live
            )
            .Select(l => GetPublicListingsMapper.ToGetPublicListingsResponse(l))
            .ToArray();

        return listings;
    }
}
