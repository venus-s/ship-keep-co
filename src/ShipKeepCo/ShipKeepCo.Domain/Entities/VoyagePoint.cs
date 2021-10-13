using System;

namespace ShipKeepCo.Domain.Entities
{
    public class VoyagePoint : AuditableEntity
    {
        public int VoyagePointId { get; set; }

        public DateTime Date { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public int VoyageId { get; set; }

        public Voyage Voyage { get; set; }
    }
}
