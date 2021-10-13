using System.Collections.Generic;

namespace ShipKeepCo.Domain.Entities
{
    public class Voyage : AuditableEntity
    {
        public int VoyageId { get; set; }

        public string Name { get; set; }

        public List<VoyagePoint> VoyagePoints { get; set; }
    }
}
