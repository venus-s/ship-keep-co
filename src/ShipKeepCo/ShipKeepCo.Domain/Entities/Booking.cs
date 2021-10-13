namespace ShipKeepCo.Domain.Entities
{
    public class Booking : AuditableEntity
    {
        public int BookingId { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public int DepartureVoyagePointId { get; set; }
        
        public VoyagePoint DepartureVoyagePoint { get; set; }

        public int ArrivalVoyagePointId { get; set; }

        public VoyagePoint ArrivalVoyagePoint { get; set; }

        public double TotalPrice { get; set; }
    }
}
