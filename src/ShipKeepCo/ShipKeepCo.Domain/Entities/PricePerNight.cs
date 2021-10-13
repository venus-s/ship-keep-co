namespace ShipKeepCo.Domain.Entities
{
    public class PricePerNight : AuditableEntity
    {
        public int PricePerNightId { get; set; }

        public double Price { get; set; }
    }
}
