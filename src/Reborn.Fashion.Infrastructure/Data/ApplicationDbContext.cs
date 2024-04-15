using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Reborn.Fashion.Application.Interfaces;
using Reborn.Fashion.Domain.Entities;

namespace Reborn.Fashion.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IConfiguration Configuration;

    public DbSet<Listing> Listings { get; set; }

    public ApplicationDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("RebornFashionDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Listing>().HasKey(l => l.Id);
    }
}
