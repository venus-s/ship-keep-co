using Microsoft.EntityFrameworkCore;
using ShipKeepCo.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShipKeepCo.Infrastructure
{
    public class ShipKeepCoContext : DbContext
    {

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<PricePerNight> PricePerNights { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

        public DbSet<VoyagePoint> VoyagePoints { get; set; }

        public ShipKeepCoContext(DbContextOptions<ShipKeepCoContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShipKeepCoContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "SYSTEM";
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.LastModifiedBy = "SYSTEM";
                        entry.Entity.LastModified = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "SYSTEM";
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
