using Quartz;
using Reborn.Fashion.Application.Interfaces;

namespace Reborn.Fashion.Infrastructure.Jobs;

public class JobScheduler : IJobScheduler
{
    private readonly ISchedulerFactory schedulerFactory;

    public JobScheduler(ISchedulerFactory schedulerFactory)
    {
        this.schedulerFactory = schedulerFactory;
    }

    public async Task ScheduleListingOpen(Guid listingId, DateTime openTime)
    {
        var job = JobBuilder
            .Create<OpenListingJob>()
            .UsingJobData(OpenListingJob.ListingIdKey, listingId)
            .Build();
        var trigger = TriggerBuilder.Create().StartAt(openTime).Build();

        var scheduler = await schedulerFactory.GetScheduler();
        await scheduler.ScheduleJob(job, trigger);
    }

    public async Task ScheduleListingClose(Guid listingId, DateTime closeTime)
    {
        var job = JobBuilder
            .Create<CloseListingJob>()
            .UsingJobData(CloseListingJob.ListingIdKey, listingId)
            .Build();
        var trigger = TriggerBuilder.Create().StartAt(closeTime).Build();

        var scheduler = await schedulerFactory.GetScheduler();
        await scheduler.ScheduleJob(job, trigger);
    }
}
