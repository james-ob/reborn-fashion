using Mediator;
using Reborn.Fashion.Application.Interfaces;
using Reborn.Fashion.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Reborn.Fashion.Application.UseCases.Listings;

public record GetListingResponse(Guid Id, string Title, string Description);

public record GetListingRequest(Guid Id) : IRequest<GetListingResponse>;

[Mapper]
public static partial class GetListingMapper
{
    public static partial GetListingResponse ToGetListingResponse(Listing listing);
}

public class GetListingHandler : IRequestHandler<GetListingRequest, GetListingResponse>
{
    private readonly IApplicationDbContext dbContext;

    public GetListingHandler(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask<GetListingResponse> Handle(
        GetListingRequest request,
        CancellationToken cancellationToken
    )
    {
        var listing =
            await dbContext.Listings.FindAsync(request.Id)
            ?? throw new ArgumentException("Listing not found");
        return GetListingMapper.ToGetListingResponse(listing);
    }
}
