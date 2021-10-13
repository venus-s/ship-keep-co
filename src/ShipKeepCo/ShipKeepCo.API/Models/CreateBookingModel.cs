namespace ShipKeepCo.API.Models
{
    public class CreateBookingModel
    {
        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public int DepartureVoyagePointId { get; set; }

        public int ArrivalVoyagePointId { get; set; }
    }
}
