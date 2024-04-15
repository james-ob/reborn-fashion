using Microsoft.EntityFrameworkCore;
using Reborn.Fashion.Domain.Entities;

namespace Reborn.Fashion.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Listing> Listings { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
