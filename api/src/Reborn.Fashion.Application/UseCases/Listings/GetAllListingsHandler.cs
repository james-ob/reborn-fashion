using Mediator;
using Reborn.Fashion.Application.Interfaces;
using Reborn.Fashion.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Reborn.Fashion.Application.UseCases.Listings;

public record GetAllListingsResponse(
    Guid Id,
    string Title,
    string Description,
    string ImageSrc,
    DateTime Start,
    DateTime? End,
    ListingStatus Status
);

public record GetAllListingsRequest() : IRequest<GetAllListingsResponse[]>;

[Mapper]
public static partial class GetAllListingsMapper
{
    [MapProperty(
        [nameof(Listing.DateRange), nameof(Listing.DateRange.Start)],
        [nameof(GetListingResponse.Start)]
    )]
    [MapProperty(
        [nameof(Listing.DateRange), nameof(Listing.DateRange.End)],
        [nameof(GetListingResponse.End)]
    )]
    public static partial GetAllListingsResponse ToGetAllListingsResponse(Listing listing);
}

public class GetAllListingsHandler
    : IRequestHandler<GetAllListingsRequest, GetAllListingsResponse[]>
{
    private readonly IApplicationDbContext dbContext;

    public GetAllListingsHandler(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask<GetAllListingsResponse[]> Handle(
        GetAllListingsRequest request,
        CancellationToken cancellationToken
    )
    {
        var listings = dbContext
            .Listings.Select(l => GetAllListingsMapper.ToGetAllListingsResponse(l))
            .ToArray();

        return listings;
    }
}
