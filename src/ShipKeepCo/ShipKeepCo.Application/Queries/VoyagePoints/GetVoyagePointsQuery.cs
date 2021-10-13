using MediatR;
using ShipKeepCo.Application.Models;
using System;
using System.Collections.Generic;

namespace ShipKeepCo.Application.Queries.VoyagePoints
{
    public class GetVoyagePointsQuery : IRequest<List<VoyagePointModel>>
    {
        public DateTime Date { get; }

        public GetVoyagePointsQuery(DateTime date)
        {
            Date = date;
        }
    }
}
