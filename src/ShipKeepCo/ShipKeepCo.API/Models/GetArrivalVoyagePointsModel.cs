using System;

namespace ShipKeepCo.API.Models
{
    public class GetArrivalVoyagePointsModel
    {
        public DateTime DepartureDate { get; set; }

        public int VoyageId { get; set; }
    }
}
