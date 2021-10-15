using MediatR;
using ShipKeepCo.Application.Models;

namespace ShipKeepCo.Application.Queries.Bookings
{
    public class GetPricePerNightQuery : IRequest<PricePerNightModel>
    {
    }
}
