using MediatR;
using ShipKeepCo.Application.Models;
using System;
using System.Collections.Generic;

namespace ShipKeepCo.Application.Queries.VoyagePoints
{
    public class GetArrivalVoyagePointsQuery : IRequest<List<VoyagePointModel>>
    {
        public int VoyageId { get; }

        public DateTime DepartureDate { get; }

        public GetArrivalVoyagePointsQuery(int voyageId, DateTime departureDate)
        {
            VoyageId = voyageId;
            DepartureDate = departureDate;
        }
    }
}
