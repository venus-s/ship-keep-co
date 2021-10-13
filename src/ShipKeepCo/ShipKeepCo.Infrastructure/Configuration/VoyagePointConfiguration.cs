using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipKeepCo.Domain.Entities;

namespace ShipKeepCo.Infrastructure.Configuration
{
    public class VoyagePointConfiguration : IEntityTypeConfiguration<VoyagePoint>
    {
        public void Configure(EntityTypeBuilder<VoyagePoint> builder)
        {
            builder.HasKey(b => b.VoyagePointId);

            builder.HasOne(b => b.Location)
                .WithMany()
                .HasForeignKey(b => b.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Voyage)
                .WithMany(b => b.VoyagePoints)
                .HasForeignKey(b => b.VoyageId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
