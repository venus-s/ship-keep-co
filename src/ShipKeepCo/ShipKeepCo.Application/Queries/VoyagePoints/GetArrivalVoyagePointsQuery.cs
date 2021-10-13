using MediatR;
using ShipKeepCo.Application.Models;
using System;
using System.Collections.Generic;

namespace ShipKeepCo.Application.Queries.VoyagePoints
{
    public class GetArrivalVoyagePointsQuery : IRequest<List<VoyagePointModel>>
    {
        public DateTime DepartureDate { get; }

        public int VoyageId { get; }

        public GetArrivalVoyagePointsQuery(DateTime departureDate, int voyageId)
        {
            DepartureDate = departureDate;
            VoyageId = voyageId;
        }
    }
}
