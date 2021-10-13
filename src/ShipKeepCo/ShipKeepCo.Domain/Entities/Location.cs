namespace ShipKeepCo.Domain.Entities
{
    public class Location : AuditableEntity
    {
        public int LocationId { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
