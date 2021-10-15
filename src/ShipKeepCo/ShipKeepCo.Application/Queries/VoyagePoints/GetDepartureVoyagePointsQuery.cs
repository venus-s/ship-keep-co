using MediatR;
using ShipKeepCo.Application.Models;
using System.Collections.Generic;

namespace ShipKeepCo.Application.Queries.VoyagePoints
{
    public class GetDepartureVoyagePointsQuery : IRequest<List<VoyagePointModel>>
    { }
}
