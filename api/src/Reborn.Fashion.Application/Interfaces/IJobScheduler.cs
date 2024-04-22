namespace Reborn.Fashion.Application.Interfaces;

public interface IJobScheduler
{
    Task ScheduleListingOpen(Guid listingId, DateTime openTime);
    Task ScheduleListingClose(Guid listingId, DateTime closeTime);
}
