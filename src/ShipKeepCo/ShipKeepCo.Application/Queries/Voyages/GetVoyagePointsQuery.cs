using MediatR;
using ShipKeepCo.Application.Models;
using System.Collections.Generic;

namespace ShipKeepCo.Application.Queries.Voyages
{
    public class GetVoyagePointsQuery : IRequest<List<VoyagePointModel>>
    { }
}
