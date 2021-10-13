using System;

namespace ShipKeepCo.Application.Models
{
    public class BookingModel
    {
        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public DateTime DepartureDate { get; set; }

        public string DepartureLocation { get; set; }

        public DateTime ArrivalDate { get; set; }

        public string ArrivalLocation { get; set; }

        public double TotalPrice { get; set; }

        public string ConfirmationNumber { get; set; }
    }
}
