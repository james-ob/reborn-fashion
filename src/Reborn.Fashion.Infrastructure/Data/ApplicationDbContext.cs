using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Reborn.Fashion.Application.Interfaces;
using Reborn.Fashion.Domain.Entities;

namespace Reborn.Fashion.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Listing> Listings { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Listing>().HasKey(l => l.Id);
        modelBuilder.Entity<Listing>().OwnsOne(l => l.DateRange);
    }

    public async Task<IDbContextTransaction> BeginTransaction()
    {
        return await Database.BeginTransactionAsync();
    }
}
