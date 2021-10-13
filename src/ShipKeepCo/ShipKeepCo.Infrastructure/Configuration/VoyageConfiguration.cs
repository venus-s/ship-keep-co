using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipKeepCo.Domain.Entities;

namespace ShipKeepCo.Infrastructure.Configuration
{
    public class VoyageConfiguration : IEntityTypeConfiguration<Voyage>
    {
        public void Configure(EntityTypeBuilder<Voyage> builder)
        {
            builder.HasKey(b => b.VoyageId);

            builder.HasMany(b => b.VoyagePoints)
                .WithOne()
                .HasForeignKey(b => b.VoyageId);
        }
    }
}
