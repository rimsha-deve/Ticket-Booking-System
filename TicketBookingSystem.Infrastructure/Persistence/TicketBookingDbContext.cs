
using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Domain.Entities;
//using TicketBookingSystem.Domain.Entities;

namespace TicketBookingSystem.Infrastructure.Persistence;

public class TicketBookingDbContext : DbContext
{
    public TicketBookingDbContext(DbContextOptions<TicketBookingDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the DbSet for Event entities.
    /// </summary>
   //public DbSet<Event> Events => Set<Event>();
   public DbSet<User> Users => Set<User>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Apply configurations for entities
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketBookingDbContext).Assembly);
    }
}
