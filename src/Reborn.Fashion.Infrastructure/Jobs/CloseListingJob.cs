using Mediator;
using Quartz;
using Reborn.Fashion.Application.UseCases.Listings;

namespace Reborn.Fashion.Infrastructure.Jobs;

public class CloseListingJob(IMediator mediator) : IJob
{
    public const string ListingIdKey = "listingId";

    public async Task Execute(IJobExecutionContext context)
    {
        Guid listingId = context.JobDetail.JobDataMap.GetGuid(ListingIdKey);
        var command = new CloseListingCommand(listingId);
        await mediator.Send(command);
    }
}
