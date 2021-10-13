using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipKeepCo.Domain.Entities;

namespace ShipKeepCo.Infrastructure.Configuration
{
    public class PricePerNightConfiguration : IEntityTypeConfiguration<PricePerNight>
    {
        public void Configure(EntityTypeBuilder<PricePerNight> builder)
        {
            builder.HasKey(b => b.PricePerNightId);
        }
    }
}
