using MediatR;
using ShipKeepCo.Application.Models;

namespace ShipKeepCo.Application.Queries.VoyagePoints
{
    public class GetPricePerNightQuery : IRequest<PricePerNightModel>
    {
    }
}
