using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipKeepCo.Domain.Entities;

namespace ShipKeepCo.Infrastructure.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.BookingId);

            builder.HasOne(b => b.DepartureVoyagePoint)
                .WithMany()
                .HasForeignKey(b => b.DepartureVoyagePointId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.ArrivalVoyagePoint)
                .WithMany()
                .HasForeignKey(b => b.ArrivalVoyagePointId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
