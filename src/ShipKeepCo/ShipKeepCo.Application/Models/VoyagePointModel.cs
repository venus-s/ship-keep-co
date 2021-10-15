using System;

namespace ShipKeepCo.Application.Models
{
    public class VoyagePointModel
    {
        public int VoyagePointId { get; set; }

        public DateTime Date { get; set; }

        public int VoyageId { get; set; }

        public int LocationId { get; set; }

        public string Location { get; set; }
    }
}
